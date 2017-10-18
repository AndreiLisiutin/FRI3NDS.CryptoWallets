-- Сохранение стран.
SELECT Service$DropFunction('Country$Save');
CREATE OR REPLACE FUNCTION Country$Save(
	_country_id UUID --Идентификатор страны.
	, _name TEXT --Название.
) 
RETURNS UUID
AS 
$$
	DECLARE
		new_country_id UUID;
	BEGIN
		IF (COALESCE(_country_id, uuid_nil()) <> uuid_nil()) THEN
			UPDATE public."country" 
			SET (name) 
			= (_name) 
			WHERE country_id = _country_id;
			new_country_id = _country_id;
		ELSE
			INSERT INTO public."country" 
				(name) 
			VALUES (_name)
			RETURNING country_id INTO new_country_id;
		END IF;
		
		RETURN new_country_id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;