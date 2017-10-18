-- Выборка сертификатов.
SELECT Service$DropFunction('Certificate$Query');
CREATE OR REPLACE FUNCTION Certificate$Query(
	_certificate_id UUID --Идентификатор сертификата.
	, _user_id UUID --идентификатор пользователя
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	CertificateId UUID
	, UserId UUID
	, CertificateTypeId INT
	, CertificateStateId INT
	, DocumentId UUID 
	, RequestedOn DATE
	, CreatedOn DATE 
	, ApprovedOn DATE
	, CertificateRequestId UUID 
	, CertificateNumber TEXT 
	, CertificateDate DATE
	, OwnerEmail TEXT
	, OwnerFirstName TEXT
	, OwnerLastName TEXT
	, OwnerPatronymic TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT certificate_id AS CertificateId
			, user_id AS UserId
			, certificate_type_id AS CertificateTypeId
			, certificate_state_id AS CertificateStateId
			, document_id AS DocumentId
			, created_on AS RequestedOn
			, requested_on AS CreatedOn
			, approved_on AS ApprovedOn
			, certificate_request_id AS CertificateRequestId
			, certificate_number AS CertificateNumber
			, certificate_date AS CertificateDate
			, owner_email AS OwnerEmail
			, owner_first_name AS OwnerFirstName
			, owner_last_name AS OwnerLastName
			, owner_patronymic AS OwnerPatronymic
		FROM public."certificate" с 
		WHERE (_certificate_id IS NULL OR с.certificate_id = _certificate_id) 
			AND (_user_id IS NULL OR с.user_id = _user_id)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;