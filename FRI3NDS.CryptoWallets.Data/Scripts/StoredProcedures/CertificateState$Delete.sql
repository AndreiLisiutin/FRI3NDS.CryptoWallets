-- Удаление статусов сертификатов.
SELECT Service$DropFunction('CertificateState$Delete');
CREATE OR REPLACE FUNCTION CertificateState$Delete(
	_id INT --идентификатор сертификата
) 
RETURNS INT
AS 
$$
	BEGIN
		DELETE FROM public."certificate_state" WHERE certificate_state_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;