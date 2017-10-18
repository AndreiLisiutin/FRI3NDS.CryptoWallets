-- Удаление типов сертификатов.
SELECT Service$DropFunction('CertificateType$Delete');
CREATE OR REPLACE FUNCTION CertificateType$Delete(
	_id INT --идентификатор типа сертификата
) 
RETURNS INT
AS 
$$
	BEGIN
		DELETE FROM public."certificate_type" WHERE certificate_type_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;