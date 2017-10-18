-- Выборка стран.
SELECT Service$DropFunction('Country$Query');
CREATE OR REPLACE FUNCTION Country$Query(
	_country_id UUID --Идентификатор страны.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	CountryId UUID
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT c.country_id AS CountryId
			, c.name AS Name
		FROM public."country" c 
		WHERE (_country_id IS NULL OR c.country_id = _country_id)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;