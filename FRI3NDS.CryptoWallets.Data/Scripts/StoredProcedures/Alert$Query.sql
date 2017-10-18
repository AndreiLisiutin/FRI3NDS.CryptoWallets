-- Выборка оповещения.
SELECT Service$DropFunction('Alert$Query');
CREATE OR REPLACE FUNCTION Alert$Query(
	_alert_id UUID --Идентификатор оповещения.
	, _user_id UUID --Идентификатор пользователя.
	, _currency_id UUID --Идентификатор главной валюты.
	, _is_active BOOLEAN --Активное ли в данный момент оповещение.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	AlertId UUID
	, UserId UUID
	, CurrencyId UUID
	, CompareCurrencyId UUID
	, MinValue DECIMAL(20,10)
	, MaxValue DECIMAL(20,10)
	, AlertFrequencyId INT
	, Email TEXT
	, Phone TEXT
	, IsPhoneAlert BOOLEAN
	, IsEmailAlert BOOLEAN
	, IsActive BOOLEAN) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT a.alert_id AS AlertId
			, a.user_id AS UserId
			, a.currency_id AS CurrencyId
			, a.compare_currency_id AS CompareCurrencyId
			, a.min_value AS MinValue
			, a.max_value AS MaxValue
			, a.alert_frequency_id AS AlertFrequencyId
			, a.email AS Email
			, a.phone AS Phone
			, a.is_phone_alert AS IsPhoneAlert
			, a.is_email_alert AS IsEmailAlert
			, a.is_active AS IsActive
		FROM public."alert" a 
		WHERE (_alert_id IS NULL OR a.alert_id = _alert_id)
			AND (_user_id IS NULL OR a.user_id = _user_id)
			AND (_currency_id IS NULL OR a.currency_id = _currency_id)
			AND (is_active IS NULL OR a.is_active = _is_active)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;