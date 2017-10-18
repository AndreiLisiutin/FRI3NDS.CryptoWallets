-- Выборка статусов сертификатов.
SELECT Service$DropFunction('CertificateState$Query');
CREATE OR REPLACE FUNCTION CertificateState$Query(
	_certificate_state_id INT --Идентификатор статуса сертификата.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	CertificateStateId INT
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT с.certificate_state_id AS CertificateStateId
			, с.name AS Name
		FROM public."certificate_state" с 
		WHERE (_certificate_state_id IS NULL OR с.certificate_state_id = _certificate_state_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;