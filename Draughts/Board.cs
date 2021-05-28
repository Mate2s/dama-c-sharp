using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Draughts.Enums;
using Draughts.Stones;

namespace Draughts
{
    public class Board : System.Windows.Forms.Panel
    {
        private int size = 400;
        private int fieldsize = 400 / 8;
        private LinkedList<Stone> stones = new LinkedList<Stone>();
        private LinkedList<Stone> stonesabletojump = new LinkedList<Stone>();
        private LinkedList<Stone> stonesjumped = new LinkedList<Stone>();
        private Colors move = Colors.WHITE;
        private Stone focusedstone = null;

        private Color color1 = Color.SteelBlue;
        private Color color2 = Color.DarkBlue;
        private int color1Transparent = 150;
        private int color2Transparent = 150;
        private int angle = 90;



        public void setMove(Colors m)
        {
            move = m;
            focusedstone = null;
            stonesabletojump.Clear();
            stonesAbleTOJump();
        }

        public LinkedList<Stone> getStones()
        {
            return stones;
        }

        public LinkedList<Stone> getStonesjumped()
        {
            return stonesjumped;
        }

        public int getFieldsize()
        {
            return fieldsize;
        }

        public Colors getMove()
        {
            return move;
        }

        public Stone getFocusedstone()
        {
            return focusedstone;
        }

        public Stone getStone(int x, int y)
        {
            foreach (Stone s in stones)
            {
                if (s.GetX() == x && s.GetY() == y)
                {
                    return s;
                }
            }
            return null;
        }

        public LinkedList<Stone> getstonesAbleTOJump()
        {
            return stonesabletojump;
        }

        public bool inJumpedList(Stone s)
        {
            foreach (Stone a in stonesjumped)
            {
                if (a.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isEnd()
        {
            foreach (Stone a in stones)
            {
                if (a.GetColor() == move)
                {
                    if (a.Movable(this) || a.Jumpable(this))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void startGame()
        {
            stones.Clear();
            stonesabletojump.Clear();
            stonesjumped.Clear();
            move = Colors.WHITE;
            focusedstone = null;
            //System.gc();
            addStones();
            Invalidate();
            //repaint();
        }

        public Actions action(int x, int y)
        {
            if (focusedstone != null)
            {
                if (stonesjumped.Count == 0)
                {
                    if (rightFocus(x, y))
                    {
                        setFocus(x, y);
                        return Actions.FOCUSED; //focused
                    }
                    if (focusedstone.CheckJump(this, x, y))
                    {
                        jump(x, y);
                        return jumpable();
                    }
                    else {
                        if (stonesabletojump.Count == 0)
                        {
                            if (focusedstone.CheckMove(this, x, y))
                            {
                                moveStone(x, y);
                                return Actions.NEXT; //jede dalsi
                            }
                            else {
                                focusedstone = null;
                                return Actions.TRY_MOVE;//zkus jet kam muzes
                            }
                        }
                        else {
                            return Actions.FOCUS_OR_JUMP;
                        }
                        //return 4;//vezmi nekoho skym muzes skakat, nebo skoc kam muzes 
                    }
                }
                else {
                    if (focusedstone.CheckJump(this, x, y))
                    {
                        jump(x, y);
                        return jumpable();
                    }
                    else {
                        return Actions.TRY_JUMP;//skoc tam kam muzes
                    }
                }
            }
            else {
                if (focusedstone == null)
                {
                    if (rightFocus(x, y))
                    {
                        setFocus(x, y);
                        return Actions.FOCUSED; //focused
                    }
                    else {
                        if (stonesabletojump.Count == 0)
                        {
                            return Actions.TRY_FOCUS; //vezmi neco scim muzes jet
                        }
                        else {
                            return Actions.TRY_FOCUS_TO_JUMP;
                        }
                    }
                }
            }
            return Actions.NEXT;
        }

        public bool checkBoard(int xx, int yy)
        {
            if (xx >= 0 && xx < 8)
            {
                if (yy >= 0 && yy < 8)
                {
                    return true;
                }
            }
            return false;
        }

        private void setFocus(int x, int y)
        {
            focusedstone = getStone(x, y);
        }

        private void removeStone(Stone s)
        {
            stones.Remove(s);
        }

        private bool rightFocus(int x, int y)
        {
            if (getStone(x, y) != null)
            {
                if (stonesabletojump.Count == 0 && getStone(x, y).GetColor() == move)
                {
                    return true;
                }

                foreach (Stone a in stonesabletojump)
                {
                    if (x == a.GetX() && y == a.GetY() && a.GetColor() == move)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void moveStone(int x, int y)
        {
            focusedstone.Move(x, y);
            endTurn();
        }

        private void jump(int x, int y)
        {
            focusedstone.Move(x, y);
        }

        private Actions jumpable()
        {
            if (focusedstone.Jumpable(this))
            {
                return Actions.KEEP_JUMPING; //skakej dal
            }
            else {
                foreach (Stone s in stonesjumped)
                {
                    removeStone(s);
                }
                stonesjumped.Clear();
                endTurn();
                return Actions.NEXT; // jede dalsi
            }
        }

        private void changeToQueen(Stone stonee)
        {
            int y = focusedstone.GetY();
            Stone s = stonee;
            if (stonee.GetColor() == Colors.WHITE)
            {
                if (y == 7)
                {
                    stones.Remove(stonee);
                    stones.AddLast(s = new Queen(stonee));
                }
            }
            else {
                if (y == 0)
                {
                    stones.Remove(stonee);
                    stones.AddLast(s = new Queen(stonee));
                }
            }
        }

        public Board copyboard()
        {
            Board n = new Board();

            foreach (Stone s in this.stones)
            {
                n.stones.AddLast(new Stone(s));
            }

            foreach (Stone s in this.stonesabletojump)
            {
                n.stonesabletojump.AddLast(new Stone(s));
            }

            foreach (Stone s in this.stonesjumped)
            {
                n.stonesjumped.AddLast(new Stone(s));
            }

            n.move = this.move;
            if (this.focusedstone != null)
            {
                n.focusedstone = new Stone(this.focusedstone);
            }

            return n;
        }

        private void endTurn()
        {
            if (focusedstone != null)
            {
                changeToQueen(focusedstone);
            }
            focusedstone = null;
            if (move == Colors.BLACK)
            {
                move = Colors.WHITE;
            }
            else {
                move = Colors.BLACK;
            }
            stonesabletojump.Clear();
            stonesAbleTOJump();

        }

        private void stonesAbleTOJump()
        {
            foreach (Stone a in stones)
            {
                if (a.Jumpable(this) && a.GetColor() == move)
                {
                    if (a is Queen)
                    {
                        stonesabletojump.AddLast(a);
                    }
                }
            }
            if (stonesabletojump.Count == 0)
            {
                foreach (Stone a in stones)
                {
                    if (a.Jumpable(this) && a.GetColor() == move)
                    {
                        stonesabletojump.AddLast(a);
                    }
                }
            }
        }

        private void addStones()
        {
            Colors color;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (y < 3)
                    {
                        if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
                        {
                            color = Colors.WHITE;
                            stones.AddLast(new Stone(x, y, color, fieldsize));
                        }
                    }
                    if (y >= 5)
                    {
                        if ((x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1))
                        {
                            color = Colors.BLACK;
                            stones.AddLast(new Stone(x, y, color, fieldsize));
                        }
                    }
                }
            }
        }

        private void drawQueen(PaintEventArgs e, Stone x)
        {
            Pen pen = new Pen(new SolidBrush(Color.Green));
            pen.Width = (float)fieldsize / 14;
            /*Graphics2D g2 = (Graphics2D)g;
            Stroke oldStroke = g2.getStroke();
            g2.setStroke(new BasicStroke(fieldsize / 14));
            g.setColor(Color.black);*/
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 12 / 20);
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 7 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20);
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 7 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20, x.GetX() * fieldsize + fieldsize * 10 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20);
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 10 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 13 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20);
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 13 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20, x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20);
            e.Graphics.DrawLine(pen, x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 12 / 20);

            /*g.drawLine(x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 12 / 20);
            g.drawLine(x.GetX() * fieldsize + fieldsize * 5 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 7 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20);
            g.drawLine(x.GetX() * fieldsize + fieldsize * 7 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20, x.GetX() * fieldsize + fieldsize * 10 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20);
            g.drawLine(x.GetX() * fieldsize + fieldsize * 10 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 13 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20);
            g.drawLine(x.GetX() * fieldsize + fieldsize * 13 / 20, x.GetY() * fieldsize + fieldsize * 9 / 20, x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20);
            g.drawLine(x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 6 / 20, x.GetX() * fieldsize + fieldsize * 15 / 20, x.GetY() * fieldsize + fieldsize * 12 / 20);
            g2.setStroke(oldStroke);*/
        }

        private void drawFocus(PaintEventArgs e)
        {
            Brush aBrush = (Brush)Brushes.Green;

            Pen pen = new Pen(new SolidBrush(Color.Green));
            pen.Width = fieldsize / 12;

            // Graphics2D g2 = (Graphics2D)e.Graphics.;
            // Stroke oldStroke = g2.getStroke();
            //  g2.setStroke(new BasicStroke(fieldsize / 12));
            e.Graphics.DrawRectangle(pen, focusedstone.GetX() * fieldsize, focusedstone.GetY() * fieldsize, fieldsize, fieldsize);
            //g2.setStroke(oldStroke);
        }

        private void drawChessBoard(PaintEventArgs e)
        {
            Brush aBrush = (Brush)Brushes.Black;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1))
                    {
                        aBrush = (Brush)Brushes.White;
                    }
                    else {
                        aBrush = (Brush)Brushes.Black;
                    }

                    e.Graphics.FillRectangle(aBrush, x * fieldsize, y * fieldsize, (x + 1) * fieldsize, (y + 1) * fieldsize);
                }
            }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            drawChessBoard(e);
            Brush aBrush = (Brush)Brushes.Black;


            foreach (Stone x in stones)
            {
                if (x.GetColor() == Colors.WHITE)
                {
                    aBrush = (Brush)Brushes.White;
                    // g.setColor(Color.white);
                }
                else {
                    aBrush = (Brush)Brushes.Blue;
                    // g.setColor(Color.blue);
                }
                e.Graphics.FillEllipse(aBrush, x.GetX() * fieldsize + fieldsize / 10, x.GetY() * fieldsize + fieldsize / 10, x.GetSize() - fieldsize / 5, x.GetSize() - fieldsize / 5);
                //g.fillOval(x.GetX() * fieldsize + fieldsize / 10, x.GetY() * fieldsize + fieldsize / 10, x.GetSize() - fieldsize / 5, x.GetSize() - fieldsize / 5);
                if (x is Queen)
                {
                    drawQueen(e, x);
                }
            }

            if (focusedstone != null)
            {
                drawFocus(e);
            }
           // Invalidate();

        }



        public Color StartColor
        {
            get { return color1; }
            set { color1 = value; Invalidate(); }
        }
        public Color EndColor
        {
            get { return color2; }
            set { color2 = value; Invalidate(); }
        }
        public int Transparent1
        {
            get { return color1Transparent; }
            set
            {
                color1Transparent = value;
                if (color1Transparent > 255)
                {
                    color1Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int Transparent2
        {
            get { return color2Transparent; }
            set
            {
                color2Transparent = value;
                if (color2Transparent > 255)
                {
                    color2Transparent = 255;
                    Invalidate();
                }
                else
                    Invalidate();
            }
        }

        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }


        public Board()
        {
        }
        /*   protected override void OnPaint(PaintEventArgs e)
           {
               base.OnPaint(e);
               Color c1 = Color.FromArgb(color1Transparent, color1);
               Color c2 = Color.FromArgb(color2Transparent, color2);
               Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);
               e.Graphics.FillRectangle(b, ClientRectangle);
               b.Dispose();
           }*/
    }
}