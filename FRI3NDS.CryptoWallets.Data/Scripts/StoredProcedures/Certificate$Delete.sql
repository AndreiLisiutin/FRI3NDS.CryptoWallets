-- Удаление сертификата.
SELECT Service$DropFunction('Certificate$Delete');
CREATE OR REPLACE FUNCTION Certificate$Delete(
	_id UUID --идентификатор сертификата
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."certificate" WHERE certificate_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;