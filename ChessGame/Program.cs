using ChessGame.BoardEntities;
using ChessGame.Chess;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Position> moves;
        Board board = new Board();

        while (true)
        {
            board.PrintBoard();

            Position pos = null;
            do
            {
                Console.Write("\nSelect piece (format: e2): ");
                string input = Console.ReadLine();
                pos = ChessHelper.ParseChessPosition(input);
            } while (!board.validPosition(pos));

            Piece piece = board.GetPiece(pos);
            moves = piece.PossibleMoves(pos);

            if (moves.Any())
            {
                Console.Clear();
                board.PrintBoard(moves);

                piece = board.RemovedPiece(pos);

                Console.Write("\nMove to: ");
                string moveInput = Console.ReadLine();
                Position newPos = ChessHelper.ParseChessPosition(moveInput);
                Piece removedPiece = board.GetPiece(newPos);

                Console.Clear();
                board.PlacePiece(piece, pos, newPos, moves);

                // END GAME
                if (removedPiece is King)
                {
                    break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No possible moves.\n");
            }

        }

        board.PrintBoard();
        Console.WriteLine("\nCheckmate!");

    }
}
