-- Выборка пользователей.
SELECT Service$DropFunction('User$Query');
CREATE OR REPLACE FUNCTION User$Query(
	_user_id UUID --идентификатор пользователя
	, _login TEXT --логин пользователя
	, _email TEXT --email пользователя
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	UserId UUID 
	, Email TEXT 
	, PasswordHash TEXT
	, Login TEXT  
	, Phone TEXT
	, IsEmailConfirmed BOOLEAN
	, IsPhoneConfirmed BOOLEAN
	, FirstName TEXT 
	, LastName TEXT 
	, CreatedOn DATE) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT u.user_id AS UserId
			, u.email AS Email  
			, u.password AS PasswordHash 
			, u.login AS Login 
			, u.phone AS Phone 
			, u.is_email_confirmed AS IsEmailConfirmed 
			, u.is_phone_confirmed AS IsPhoneConfirmed 
			, u.first_name AS FirstName 
			, u.last_name AS LastName 
			, u.created_on AS CreatedOn 
		FROM public."user" u 
		WHERE (_user_id IS NULL OR u.user_id = _user_id) 
			AND (_login IS NULL OR u.login = _login)
			AND (_email IS NULL OR u.email = _email)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;