-- Сохранение статусов сертификатов.
SELECT Service$DropFunction('CertificateState$Save');
CREATE OR REPLACE FUNCTION CertificateState$Save(
	_certificate_state_id INT --Идентификатор статуса сертификата.
	, _name TEXT --Название.
) 
RETURNS INT
AS 
$$
	DECLARE
		new_certificate_state_id INT;
	BEGIN
	
		IF (_certificate_state_id > 0) THEN
			UPDATE public."certificate_state" 
			SET (name) 
			= (_name) 
			WHERE certificate_state_id = _certificate_state_id;
			new_certificate_state_id = _certificate_state_id;
		ELSE
			INSERT INTO public."certificate_state" 
				(name) 
			VALUES (_name)
			RETURNING certificate_state_id INTO new_certificate_state_id;
		END IF;
		
		RETURN new_certificate_state_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;