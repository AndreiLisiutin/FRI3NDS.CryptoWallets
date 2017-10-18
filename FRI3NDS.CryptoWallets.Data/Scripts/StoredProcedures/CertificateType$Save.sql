-- Сохранение типов сертификатов.
SELECT Service$DropFunction('CertificateType$Save');
CREATE OR REPLACE FUNCTION CertificateType$Save(
	_certificate_type_id INT --Идентификатор статуса сертификата.
	, _name TEXT --Название.
) 
RETURNS INT
AS 
$$
	DECLARE
		new_certificate_type_id INT;
	BEGIN
	
		IF (_certificate_type_id > 0) THEN
			UPDATE public."certificate_type" 
			SET (name) 
			= (_name) 
			WHERE certificate_type_id = _certificate_type_id;
			new_certificate_type_id = _certificate_type_id;
		ELSE
			INSERT INTO public."certificate_type" 
				(name) 
			VALUES (_name)
			RETURNING certificate_type_id INTO new_certificate_type_id;
		END IF;
		
		RETURN new_certificate_type_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;