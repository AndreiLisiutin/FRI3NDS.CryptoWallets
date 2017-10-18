-- Выборка регионов.
SELECT Service$DropFunction('Region$Query');
CREATE OR REPLACE FUNCTION Region$Query(
	_region_id UUID --Идентификатор региона.
	, _country_id UUID --Идентификатор страны.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	RegionId UUID
	, CountryId UUID
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT r.region_id AS RegionId
			, r.country_id AS CountryId
			, r.name AS Name
		FROM public."region" r 
		WHERE (_region_id IS NULL OR r.region_id = _region_id)
			AND (_country_id IS NULL OR r.country_id = _country_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;