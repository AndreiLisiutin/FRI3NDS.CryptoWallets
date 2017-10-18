-- Удаление кошельков.
SELECT Service$DropFunction('Wallet$Delete');
CREATE OR REPLACE FUNCTION Wallet$Delete(
	_id UUID --идентификатор кошелька
) 
RETURNS UUID
AS 
$$
	BEGIN
		DELETE FROM public."wallet" WHERE wallet_id = _id;
		RETURN _id;
	END;
$$ 
LANGUAGE plpgsql VOLATILE;