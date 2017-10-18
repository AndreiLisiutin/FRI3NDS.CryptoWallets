-- Выборка городов.
SELECT Service$DropFunction('City$Query');
CREATE OR REPLACE FUNCTION City$Query(
	_city_id UUID --Идентификатор города.
	, _region_id UUID --Идентификатор региона.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	CityId UUID
	, RegionId UUID
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT с.city_id AS CityId
			, с.region_id AS RegionId
			, с.name AS Name
		FROM public."city" с 
		WHERE (_city_id IS NULL OR с.city_id = _city_id) 
			AND (_region_id IS NULL OR с.region_id = _region_id) 
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;