-- Сохранение сертификатов.
SELECT Service$DropFunction('Certificate$Save');
CREATE OR REPLACE FUNCTION Certificate$Save(
	_certificate_id UUID --Идентификатор сертификата.
	, _user_id UUID --Идентификатор пользователя-владельца.
	, _certificate_type_id INT --Тип сертификата (Юрлицо, физлицо и т.п.)
	, _certificate_state_id INT --Статус запроса на сертификат.
	, _document_id UUID --Идентификатор документа с файлами персональных документов пользователя.
	, _created_on DATE --Дата создания сертификата в нашей системе.
	, _requested_on DATE --Дата запроса сертификата в 1С.
	, _approved_on DATE --Дата подтверждения сертификата.
	, _certificate_request_id UUID --Идентификатор запроса сертификата в 1С.
	, _certificate_number TEXT --Номер сертификата (данные из сертификата).
	, _certificate_date DATE --Дата сертификата (данные из сертификата).
	, _owner_email TEXT --Email владельца (данные из сертификата).
	, _owner_first_name TEXT --Имя владельца (данные из сертификата).
	, _owner_last_name TEXT --Фамилия владельца (данные из сертификата).
	, _owner_patronymic TEXT --Отчество владельца (данные из сертификата).
) 
RETURNS UUID
AS 
$$
	DECLARE
		new_certificate_id UUID;
	BEGIN
	
		IF (COALESCE(_certificate_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."certificate" 
			SET (user_id, certificate_type_id, certificate_state_id, document_id, created_on, requested_on, approved_on, certificate_request_id
				, certificate_number, certificate_date, owner_email, owner_first_name, owner_last_name, owner_patronymic) 
			= (_user_id, _certificate_type_id, _certificate_state_id, _document_id, _created_on, _requested_on, _approved_on, _certificate_request_id
				, _certificate_number, _certificate_date, _owner_email, _owner_first_name, _owner_last_name, _owner_patronymic) 
			WHERE certificate_id = _certificate_id;
			new_certificate_id = _certificate_id;
		ELSE
			INSERT INTO public."certificate" 
				(user_id, certificate_type_id, certificate_state_id, document_id, created_on, requested_on, approved_on, certificate_request_id
				, certificate_number, certificate_date, owner_email, owner_first_name, owner_last_name, owner_patronymic) 
			VALUES (_user_id, _certificate_type_id, _certificate_state_id, _document_id, _created_on, _requested_on, _approved_on, _certificate_request_id
				, _certificate_number, _certificate_date, _owner_email, _owner_first_name, _owner_last_name, _owner_patronymic)
			RETURNING certificate_id INTO new_certificate_id;
		END IF;
		
		RETURN new_certificate_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;