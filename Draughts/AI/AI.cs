using System;
using System.Collections.Generic;
using Draughts.Enums;
using Draughts.Stones;


namespace Draughts.AI
{
    public class AI
    {

        private Board board = null;
        private LinkedList<Stone> movablestones = new LinkedList<Stone>();
        private Colors aicolor;
        private Stone focus = null;
        private LinkedList<Point> pointstomove = new LinkedList<Point>();

        public AI()
        {
        }
        public AI(Board b)
        {
            board = b;
        }

        public void SetBoard(Board bo)
        {
            board = bo;
        }

        public void AIFocus()
        {
            focus = board.getFocusedstone();
            aicolor = board.getMove();
            movablestones.Clear();
            if (focus == null)
            {
                foreach (Stone s in board.getstonesAbleTOJump())
                {
                    movablestones.AddLast(s);
                }
                if (movablestones.Count==0)
                {
                    CheckMovableStones();
                }

                Random r = new Random();
                int i=r.Next(movablestones.Count);
                foreach (Stone a in movablestones)
                {
                    if (i == 0)
                    {
                        focus = a;
                    }
                    i--;
                }
                //focus = movablestones.get(r.Next((movablestones.Count));
                board.action(focus.GetX(), focus.GetY());
                //System.out.println(focus.GetX() + " " + focus.GetY());

            }
        }

        public bool AIAction()
        {

            if (focus.Jumpable(board))
            {
                if (AiJump(focus))
                {
                    return true;
                }
            }
            else {
                AiMove(focus);
                return true;
            }
            return false;
        }

        private bool AiJump(Stone s)
        {
            pointstomove.Clear();
            if (s is Stone) {
                if (s.CheckJumpWithoutAdd(board, s.GetX() + 2, s.GetY() + 2))
                {
                    pointstomove.AddLast(new Point(s.GetX() + 2, s.GetY() + 2));
                }
                if (s.CheckJumpWithoutAdd(board, s.GetX() - 2, s.GetY() + 2))
                {
                    pointstomove.AddLast(new Point(s.GetX() - 2, s.GetY() + 2));
                }
                if (s.CheckJumpWithoutAdd(board, s.GetX() + 2, s.GetY() - 2))
                {
                    pointstomove.AddLast(new Point(s.GetX() + 2, s.GetY() - 2));
                }
                if (s.CheckJumpWithoutAdd(board, s.GetX() - 2, s.GetY() - 2))
                {
                    pointstomove.AddLast(new Point(s.GetX() - 2, s.GetY() - 2));
                }
            }

            int x;
            int y;
            if (s is Queen) {
                x = s.GetX();
                y = s.GetY();

                for (int i = x + 2, j = y + 2; board.checkBoard(i, j); i++, j++)
                {
                    if (s.CheckJumpWithoutAdd(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x - 2, j = y + 2; board.checkBoard(i, j); i--, j++)
                {
                    if (s.CheckJumpWithoutAdd(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x + 2, j = y - 2; board.checkBoard(i, j); i++, j--)
                {
                    if (s.CheckJumpWithoutAdd(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x - 2, j = y - 2; board.checkBoard(i, j); i--, j--)
                {
                    if (s.CheckJumpWithoutAdd(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }
            }

            Random r = new Random();
            int ii = r.Next(pointstomove.Count);
            Point help = null;
            foreach (Point a in pointstomove)
            {
                if (ii == 0)
                {
                    help = a;
                }
                ii--;
            }
            //Point help = pointstomove.get(r.nextInt(pointstomove.size()));
            x = help.GetX();
            y = help.GetY();
            pointstomove.Clear();

            return board.action(x, y) == Actions.NEXT;

        }

        private void AiMove(Stone s)
        {
            pointstomove.Clear();
            if (s is Stone) {
                if (s.CheckMove(board, s.GetX() + 1, s.GetY() + 1))
                {
                    pointstomove.AddLast(new Point(s.GetX() + 1, s.GetY() + 1));
                }
                if (s.CheckMove(board, s.GetX() - 1, s.GetY() + 1))
                {
                    pointstomove.AddLast(new Point(s.GetX() - 1, s.GetY() + 1));
                }
                if (s.CheckMove(board, s.GetX() + 1, s.GetY() - 1))
                {
                    pointstomove.AddLast(new Point(s.GetX() + 1, s.GetY() - 1));
                }
                if (s.CheckMove(board, s.GetX() - 1, s.GetY() - 1))
                {
                    pointstomove.AddLast(new Point(s.GetX() - 1, s.GetY() - 1));
                }
            }

            if (s is Queen) {
                int x = s.GetX();
                int y = s.GetY();

                for (int i = x + 1, j = y + 1; board.checkBoard(i, j); i++, j++)
                {
                    if (s.CheckMove(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x - 1, j = y + 1; board.checkBoard(i, j); i--, j++)
                {
                    if (s.CheckMove(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x + 1, j = y - 1; board.checkBoard(i, j); i++, j--)
                {
                    if (s.CheckMove(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }

                for (int i = x - 1, j = y - 1; board.checkBoard(i, j); i--, j--)
                {
                    if (s.CheckMove(board, i, j))
                    {
                        pointstomove.AddLast(new Point(i, j));
                    }
                }
            }

            Random r = new Random();
            int ii = r.Next(pointstomove.Count);
            Point helpp = null;
            foreach (Point a in pointstomove)
            {
                if (ii == 0)
                {
                    helpp = a;
                }
                ii--;
            }
            //Point helpp = pointstomove.get(r.nextInt(pointstomove.size()));
            board.action(helpp.GetX(), helpp.GetY());
            //System.out.println(help.GetX() + " " + help.GetY());
            pointstomove.Clear();

        }

        private void CheckMovableStones()
        {
            foreach (Stone s in board.getStones())
            {
                if (s.GetColor() == aicolor)
                {
                    if (s.Movable(board))
                    {
                        movablestones.AddLast(s);
                    }
                }
            }
        }
    }
}
