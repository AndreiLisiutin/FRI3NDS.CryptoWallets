-- Сохранение кошельков пользователя.
SELECT Service$DropFunction('Wallet$Save');
CREATE OR REPLACE FUNCTION Wallet$Save(
	_wallet_id UUID --Идентификатор кошелька.
	, _currency_id UUID --Идентификатор валюты.
	, _user_id TEXT --Идентификатор пользователя.
	, _balance TEXT -- Дата создания.
	, _created_on DATE --Дата создания вопроса.
	, _last_updated_on DATE --Дата последнего обновления баланса. (Подумать, а надо ли оно, возможно, будет удалено отсюда).
	, _address DATE --Адрес (для криптовалютных кошельков).
) 

RETURNS UUID
AS 
$$
	DECLARE
		new_wallet_id UUID;
	BEGIN
		IF (COALESCE(_wallet_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."question" 
			SET (currency_id, user_id, balance, created_on, last_updated_on, address) 
			= (_currency_id, _user_id, _balance, _created_on, _last_updated_on, _address) 
			WHERE wallet_id = _wallet_id;
			new_wallet_id = _wallet_id;
		ELSE
			INSERT INTO public."wallet" 
				(currency_id, user_id, balance, created_on, last_updated_on, address) 
			VALUES (_currency_id, _user_id, _balance, _created_on, _last_updated_on, _address)
			RETURNING wallet_id INTO new_wallet_id;
		END IF;
		
		RETURN new_wallet_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;