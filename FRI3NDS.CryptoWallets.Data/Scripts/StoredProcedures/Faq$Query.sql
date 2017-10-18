-- Выборка ЧаВо.
SELECT Service$DropFunction('Faq$Query');
CREATE OR REPLACE FUNCTION Faq$Query(
	_faq_id UUID --Идентификатор ЧаВо.
	, _page_size INTEGER = 1000000 --размер страницы
	, _page_number INTEGER = 0 --номер страницы
)
RETURNS TABLE (
	FaqId UUID
	, Question TEXT
	, Answer TEXT
	, CreatedOn DATE) 
AS 
$$
	BEGIN
		RETURN QUERY
		 
		SELECT f.faq_id AS QuestionId
			, f.question AS Question
			, f.answer AS Answer
			, f.created_on AS CreatedOn
		FROM public."faq" f 
		WHERE (_faq_id IS NULL OR f.faq_id = _faq_id)
		OFFSET _page_number * _page_size LIMIT _page_size;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;