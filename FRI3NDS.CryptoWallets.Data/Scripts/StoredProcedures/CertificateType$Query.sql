-- Выборка типов сертификатов.
SELECT Service$DropFunction('CertificateType$Query');
CREATE OR REPLACE FUNCTION CertificateType$Query(
	_certificate_type_id INT --Идентификатор типа сертификата.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	CertificateTypeId INT
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT с.certificate_type_id AS CertificateTypeId
			, с.name AS Name
		FROM public."certificate_state" с 
		WHERE (_certificate_type_id IS NULL OR с.certificate_type_id = _certificate_type_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;