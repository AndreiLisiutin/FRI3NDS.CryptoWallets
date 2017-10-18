-- Сохранение оповещения.
SELECT Service$DropFunction('Alert$Save');
CREATE OR REPLACE FUNCTION Alert$Save(
	_alert_id UUID --Идентификатор оповещения.
	, _user_id UUID --Идентификатор пользователя.
	, _currency_id UUID --Идентификатор главной валюты.
	, _compare_currency_id UUID --Идентификатор валюты, по отношении к которой должна измениться главная.
	, _min_value DECIMAL(20,10) --Минимальный порог срабатывания оповещения.
	, _max_value DECIMAL(20,10) --Максимальный порог срабатывания оповещения.
	, _alert_frequency_id INT --Частота срабатывания (один раз/всегда).
	, _email TEXT --Емайл пользователя.
	, _phone TEXT -- Номер телефона пользователя.
	, _is_phone_alert BOOLEAN --Посылать ли оповещения по телефону.
	, _is_email_alert BOOLEAN --Посылать ли оповещения на электронную почту.
	, _is_active BOOLEAN --Активное ли в данный момент оповещение.
) 

RETURNS UUID
AS 
$$
	DECLARE
		new_alert_id UUID;
	BEGIN
		IF (COALESCE(_alert_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."alert" 
			SET (user_id, currency_id, compare_currency_id, min_value, max_value, alert_frequency_id, email, phone, is_phone_alert, is_email_alert, is_active) 
			= (_user_id, _currency_id, _compare_currency_id, _min_value, _max_value, _alert_frequency_id, _email, _phone, _is_phone_alert, _is_email_alert, _is_active) 
			WHERE alert_id = _alert_id;
			new_alert_id = _alert_id;
		ELSE
			INSERT INTO public."alert" 
				(user_id, currency_id, compare_currency_id, min_value, max_value, alert_frequency_id, email, phone, is_phone_alert, is_email_alert, is_active) 
			VALUES (_user_id, _currency_id, _compare_currency_id, _min_value, _max_value, _alert_frequency_id, _email, _phone, _is_phone_alert, _is_email_alert, _is_active)
			RETURNING alert_id INTO new_alert_id;
		END IF;
		
		RETURN new_alert_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;