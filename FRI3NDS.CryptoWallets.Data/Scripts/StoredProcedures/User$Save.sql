-- Сохранение пользователей.
SELECT Service$DropFunction('User$Save');
CREATE OR REPLACE FUNCTION User$Save(
	_user_id UUID --идентификатор пользователя
	, _email TEXT --email
	, _password TEXT --хэш пароля
	, _login TEXT --логин
	, _is_email_confirmed BOOLEAN --подтвержден ли email
	, _is_phone_confirmed BOOLEAN --подтвержден ли телефон
	, _first_name TEXT --имя
	, _last_name TEXT --фамилия
	, _created_on DATE --дата создания пользователя
) 
RETURNS UUID
AS 
$$
	DECLARE
		new_user_id UUID;
	BEGIN
	
		IF (COALESCE(_user_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."user" 
			SET (email, password, login, is_email_confirmed, is_phone_confirmed, first_name, last_name, created_on) 
			= (_email, _password, _login, _is_email_confirmed, _is_phone_confirmed, _first_name, _last_name, _created_on) 
			WHERE user_id = _user_id;
			new_user_id = _user_id;
		ELSE
			INSERT INTO public."user" 
			(email, password, login, is_email_confirmed, is_phone_confirmed, first_name, last_name, created_on) 
			VALUES (_email, _password, _login, _is_email_confirmed, _is_phone_confirmed, _first_name, _last_name, _created_on)
			RETURNING user_id INTO new_user_id;
		END IF;
		
		RETURN new_user_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;