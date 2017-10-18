-- Выборка типов частоты оповещений.
SELECT Service$DropFunction('AlertFrequency$Query');
CREATE OR REPLACE FUNCTION AlertFrequency$Query(
	_alert_frequency_id INT --Идентификатор частоты срабатывания оповещения.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	AlertFrequencyId INT
	, Name TEXT) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT af.alert_frequency_id AS AlertFrequencyId
			, af.name AS Name
		FROM public."alert_frequency" af 
		WHERE (_alert_frequency_id IS NULL OR af.alert_frequency_id = _alert_frequency_id)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;