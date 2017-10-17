-- Удаление пользователей.
SELECT Service$DropFunction('User$Delete');
CREATE OR REPLACE FUNCTION User$Delete(
	_id UUID --идентификатор пользователя
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."user" WHERE user_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;