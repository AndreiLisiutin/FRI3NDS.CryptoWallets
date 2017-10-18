-- Сохранение городов.
SELECT Service$DropFunction('City$Save');
CREATE OR REPLACE FUNCTION City$Save(
	_city_id UUID --Идентификатор города.
	, _region_id UUID --Идентификатор региона.
	, _name TEXT --Название.
) 
RETURNS UUID
AS 
$$
	DECLARE
		new_city_id UUID;
	BEGIN
	
		IF (COALESCE(_city_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."city" 
			SET (region_id, name) 
			= (_region_id, _name) 
			WHERE city_id = _city_id;
			new_city_id = _city_id;
		ELSE
			INSERT INTO public."city" 
				(region_id, name) 
			VALUES (_region_id, _name)
			RETURNING city_id INTO new_city_id;
		END IF;
		
		RETURN new_city_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;