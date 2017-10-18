-- Сохранение регионов.
SELECT Service$DropFunction('Region$Save');
CREATE OR REPLACE FUNCTION Region$Save(
	_region_id UUID --Идентификатор региона.
	, _country_id UUID --Идентификатор страны.
	, _name TEXT --Название.
) 
RETURNS UUID
AS 
$$
	DECLARE
		new_region_id UUID;
	BEGIN
		IF (COALESCE(_region_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."region" 
			SET (country_id, name) 
			= (_country_id, _name) 
			WHERE region_id = _region_id;
			new_region_id = _region_id;
		ELSE
			INSERT INTO public."region" 
				(country_id, name) 
			VALUES (_country_id, _name)
			RETURNING region_id INTO new_region_id;
		END IF;
		
		RETURN new_region_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;