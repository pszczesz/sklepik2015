using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace RuchProstokata1 {
    internal class Move {
        public enum Direction {
            Up,
            Down,
            Left,
            Right,
        } ;

        public IMoveable Client { get; set; }
        private const int Delta = 8;
       
        public int DS { get; set; }
        public IEnumerable<SceneElement> GraphArticle { get; set; }
        public FrameworkElement Arena { get; set; }
        public bool IsColision { get; set; }
        public SceneElement GetColisionWith { get; set; }

        public void ColisionDetect(Direction direction) {
            if (IsColision) IsColision = false;
            IsColision = SetColision(direction,Delta);
        }

        public SceneElement ColisionWith(Direction direction,int dl) {
            var currentBounds = GetBounds(Client.GraphElem, Arena);
            VirtualMoveRectangle(ref currentBounds, direction,dl);
            foreach (var graphElement in GraphArticle) {
                if (GetBounds(graphElement.GraphElem, Arena).IntersectsWith(currentBounds)) {
                    return graphElement;
                }
            }
            return null;
        }

        private static void VirtualMoveRectangle(ref Rect currentBounds, Direction direction,int dl) {
            double hight = currentBounds.Height;
            double width = currentBounds.Width;
            switch (direction) {
                case Direction.Up:

                    currentBounds.Y = currentBounds.Top - dl;
                    currentBounds.Height = hight;
                    break;
                case Direction.Down:

                    currentBounds.Y = currentBounds.Top + dl;
                    currentBounds.Height = hight;
                    break;
                case Direction.Left:
                    currentBounds.X = currentBounds.X - dl;
                    currentBounds.Width = width;
                    break;
                case Direction.Right:
                    currentBounds.X = currentBounds.X + dl;
                    currentBounds.Width = width;
                    break;
            }
        }
        private bool ColisionWithArena(Direction direction) {
            var currentBounds = GetBounds(Client.GraphElem, Arena);
            VirtualMoveRectangle(ref currentBounds, direction,Delta);
            switch (direction) {
                case Direction.Up:
                    if (currentBounds.Top < 0) return true;
                    break;
                case Direction.Down:
                    if (currentBounds.Bottom > Arena.Height) return true;
                    break;
                case Direction.Left:
                    if (currentBounds.Left <0 ) return true;
                    break;
                case Direction.Right:
                    if (currentBounds.Right > Arena.ActualWidth) return true;
                    break;
            }
            return false;
        }
        private bool SetColision(Direction direction,int dl) {
            SceneElement colisionWith = ColisionWith(direction, dl);

            if (colisionWith == null && !ColisionWithArena(direction)) return false;
            if (colisionWith != null) colisionWith = ColisionWith(direction, (int) dl/2);
            if (colisionWith == null && !ColisionWithArena(direction)) {
                DS = Delta/2;
                return false;
            }
            if (colisionWith != null) 
               // MessageBox.Show("Nastapiła kolizja z przedmiotem : " + colisionWith.Name);
                GetColisionWith = colisionWith;
            
            return true;
        
    }

        private Rect GetBounds(FrameworkElement elem, FrameworkElement arena) {
            GeneralTransform transform = elem.TransformToVisual(arena);
            return transform.TransformBounds(new Rect(0, 0, elem.ActualWidth, elem.ActualHeight));
        }

        public void MoveUp(FrameworkElement element, TranslateTransform tr1) {
            ColisionDetect(Direction.Up);
            if (!IsColision) {
                tr1.Y -= DS;
            }
        }

        public void MoveDown(FrameworkElement element, TranslateTransform tr1) {
            ColisionDetect(Direction.Down);
            if (!IsColision) {
                tr1.Y += DS;
            }
        }

        public void MoveLeft(FrameworkElement element, TranslateTransform tr1) {
            ColisionDetect(Direction.Left);
            if (!IsColision) {
                tr1.X -= DS;
            }
        }

        public void MoveRight(FrameworkElement element, TranslateTransform tr1) {
            ColisionDetect(Direction.Right);
            if (!IsColision) {
                tr1.X += DS;
            }
        }

        public Move(IMoveable client, FrameworkElement arena, IEnumerable<SceneElement> elements) {
            Client = client;
            Arena = arena;
            IsColision = false;
            GraphArticle = elements;
            DS = Delta;
        }
    }
}