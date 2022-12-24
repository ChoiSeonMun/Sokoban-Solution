using System;

namespace Sokoban
{
    class Program
    {
        // 방향을 위한 열거형 정의
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        static void Main()
        {
            // 초기 세팅
            Console.ResetColor();                               // 컬러를 초기화한다.
            Console.CursorVisible = false;                      // 커서를 숨긴다.
            Console.Title = "My Sokoban";                       // 타이틀을 설정한다.
            Console.BackgroundColor = ConsoleColor.DarkBlue;    // 배경색을 설정한다.
            Console.ForegroundColor = ConsoleColor.Gray;        // 글꼴색을 설정한다.
            Console.Clear();                                    // 콘솔 창에 출력된 내용을 모두 지운다.

            // 기호 상수 정의
            const int CONSOLE_MIN_X = 0;
            const int CONSOLE_MIN_Y = 0;
            const int CONSOLE_MAX_X = 15;
            const int CONSOLE_MAX_Y = 10;

            const int INITIAL_PLAYER_X = 0;
            const int INITIAL_PLAYER_Y = 0;
            const string PLAYER_STRING = "P";

            const string BOX_STRING = "B";
            const string WALL_STRING = "W";
            const string GOAL_STRING = "G";

            const int GOAL_COUNT = 3;
            const int BOX_COUNT = GOAL_COUNT;
            const int WALL_COUNT = 3;

            // 플레이어 위치 좌표
            int playerX = INITIAL_PLAYER_X;
            int playerY = INITIAL_PLAYER_Y;
            Direction playerDirection = Direction.Left;

            // 박스 좌표
            int[] boxPositionsX = new int[BOX_COUNT] { 1, 3, 5 };
            int[] boxPositionsY = new int[BOX_COUNT] { 4, 2, 9 };

            // 벽 좌표
            int[] wallPositionsX = new int[WALL_COUNT] { 2, 7, 6 };
            int[] wallPositionsY = new int[WALL_COUNT] { 4, 5, 3 };

            // 골 좌표
            int[] goalPositionsX = new int[GOAL_COUNT] { 3, 5, 8 };
            int[] goalPositionsY = new int[GOAL_COUNT] { 3, 6, 3 };

            // 게임 루프
            while (true)
            {
                // ======================= Render ==========================
                // 이전 프레임을 지운다.
                Console.Clear();

                // 플레이어를 그려준다.
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(PLAYER_STRING);

                // 박스를 그려준다.
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    Console.SetCursorPosition(boxPositionsX[i], boxPositionsY[i]);
                    Console.Write(BOX_STRING);
                }

                // 벽을 그려준다.
                for (int i = 0; i < WALL_COUNT; ++i)
                {
                    Console.SetCursorPosition(wallPositionsX[i], wallPositionsY[i]);
                    Console.Write(WALL_STRING);
                }

                // 목표 지점을 그려준다.
                for (int i = 0; i < GOAL_COUNT; ++i)
                {
                    Console.SetCursorPosition(goalPositionsX[i], goalPositionsY[i]);
                    Console.Write(GOAL_STRING);
                }

                // ======================= ProcessInput =======================
                ConsoleKeyInfo currentKeyInfo = Console.ReadKey();

                // ======================= Update =======================
                // 플레이어 업데이트
                // 위로 이동
                if (currentKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerY = (int)Math.Max(CONSOLE_MIN_Y, playerY - 1);
                    playerDirection = Direction.Up;
                }

                // 아래로 이동
                if (currentKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    playerY = (int)Math.Min(playerY + 1, CONSOLE_MAX_Y);
                    playerDirection = Direction.Down;
                }

                // 왼쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    playerX = (int)Math.Max(CONSOLE_MIN_X, playerX - 1);
                    playerDirection = Direction.Left;
                }

                // 오른쪽으로 이동 
                if (currentKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerX = (int)Math.Min(playerX + 1, CONSOLE_MAX_X);
                    playerDirection = Direction.Right;
                }

                // 벽 충돌 처리
                for (int i = 0; i < WALL_COUNT; ++i)
                {
                    if (playerX != wallPositionsX[i] || playerY != wallPositionsY[i])
                    {
                        continue;
                    }

                    switch (playerDirection)
                    {
                        case Direction.Left:
                            playerX = playerX + 1;
                            break;
                        case Direction.Right:
                            playerX = playerX - 1;
                            break;
                        case Direction.Up:
                            playerY = playerY + 1;
                            break;
                        case Direction.Down:
                            playerY = playerY - 1;
                            break;
                        default:
                            Console.WriteLine("오류 발생");
                            break;
                    }
                }

                // 박스 업데이트
                for (int i = 0; i < BOX_COUNT; ++i)
                {
                    int boxX = boxPositionsX[i];
                    int boxY = boxPositionsY[i];

                    if (playerX != boxX || playerY != boxY)
                    {
                        continue;
                    }

                    switch (playerDirection)
                    {
                        case Direction.Left:
                            {
                                bool canMove = true;
                                if (boxX == CONSOLE_MIN_X)
                                {
                                    canMove = false;
                                }
                                else
                                {
                                    for (int j = 0; j < WALL_COUNT; ++j)
                                    {
                                        if (boxX - 1 == wallPositionsX[j] && boxY == wallPositionsY[j])
                                        {
                                            canMove = false;

                                            break;
                                        }
                                    }
                                }

                                if (canMove)
                                {
                                    boxX = boxX - 1;
                                }
                                else
                                {
                                    playerX = boxX + 1;
                                }
                            }
                            break;
                        case Direction.Right:
                            {
                                bool canMove = true;
                                if (boxX == CONSOLE_MAX_X)
                                {
                                    canMove = false;
                                }
                                else
                                {
                                    for (int j = 0; j < WALL_COUNT; ++j)
                                    {
                                        if (boxX + 1 == wallPositionsX[j] && boxY == wallPositionsY[j])
                                        {
                                            canMove = false;

                                            break;
                                        }
                                    }
                                }

                                if (canMove)
                                {
                                    boxX = boxX + 1;
                                }
                                else
                                {
                                    playerX = boxX - 1;
                                }
                            }
                            
                            break;
                        case Direction.Up:
                            {
                                bool canMove = true;
                                if (boxY == CONSOLE_MIN_Y)
                                {
                                    canMove = false;
                                }
                                else
                                {
                                    for (int j = 0; j < WALL_COUNT; ++j)
                                    {
                                        if (boxX == wallPositionsX[j] && boxY - 1 == wallPositionsY[j])
                                        {
                                            canMove = false;

                                            break;
                                        }
                                    }
                                }

                                if (canMove)
                                {
                                    boxY = boxY - 1;
                                }
                                else
                                {
                                    playerY = boxY + 1;
                                }
                            }
                            break;
                        case Direction.Down:
                            {
                                bool canMove = true;
                                if (boxY == CONSOLE_MAX_Y)
                                {
                                    canMove = false;
                                }
                                else
                                {
                                    for (int j = 0; j < WALL_COUNT; ++j)
                                    {
                                        if (boxX == wallPositionsX[j] && boxY + 1 == wallPositionsY[j])
                                        {
                                            canMove = false;

                                            break;
                                        }
                                    }
                                }

                                if (canMove)
                                {
                                    boxY = boxY + 1;
                                }
                                else
                                {
                                    playerY = boxY - 1;
                                }
                            }
                            break;
                        default:
                            Console.WriteLine($"[Error] 플레이어 방향 : {playerDirection}");
                            break;
                    }

                    boxPositionsX[i] = boxX;
                    boxPositionsY[i] = boxY;
                }

                // 목표 달성 확인
                int count = 0;
                for (int i = 0; i < GOAL_COUNT; ++i)
                {
                    for (int j = 0; j < BOX_COUNT; ++j)
                    {
                        if (goalPositionsX[i] == boxPositionsX[j] && goalPositionsY[i] == boxPositionsY[j])
                        {
                            ++count;

                            break;
                        }
                    }
                }

                if (count == GOAL_COUNT)
                {
                    Console.Clear();
                    Console.WriteLine("축하합니다. 클리어 하셨습니다.");

                    break;
                }
            }
        }
    }
}