-- Выборка кошельков пользователя.
SELECT Service$DropFunction('Wallet$Query');
CREATE OR REPLACE FUNCTION Wallet$Query(
	_wallet_id UUID --Идентификатор вопроса.
	, _currency_id UUID --Идентификатор валюты.
	, _user_id UUID --Идентификатор пользователя.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	WalletId UUID
	, CurrencyId UUID
	, UserId UUID
	, Balance DECIMAL(20,10)
	, CreatedOn DATE
	, LastUpdatedOn DATE
	, Address TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT w.wallet_id AS WalletId
			, w.currency_id AS CurrencyId
			, w.user_id AS UserId
			, w.balance AS Balance
			, w.created_on AS CreatedOn
			, w.last_updated_on AS LastUpdatedOn
			, w.address AS Address
		FROM public."wallet" w 
		WHERE (_wallet_id IS NULL OR w.wallet_id = _wallet_id)
			AND (_currency_id IS NULL OR w.currency_id = _currency_id) 
			AND (_user_id IS NULL OR w.user_id = _user_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;