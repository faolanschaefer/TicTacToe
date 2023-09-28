/* 
 * Programmed by: Faolan Schaefer
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSchaeferAssignment1
{
    public partial class TicTacToe : Form
    {
        private const int SIZE_OF_GRID = 3;
        private Image xImg = Properties.Resources.x;
        private Image oImg = Properties.Resources.o;
        private Player activePlayer = Player.x;
        private Player[,] grid = new Player[SIZE_OF_GRID, SIZE_OF_GRID];

        public TicTacToe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Represents one of the possible players
        /// </summary>
        enum Player
        {
            empty, x, o
        }

        /// <summary>
        /// Displays a message to the lblMessage label
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="color">Forecolor of message</param>
        private void SendMessage(string message, Color color)
        {
            lblMessage.ForeColor = color;
            lblMessage.Text = message;
        }

        /// <summary>
        /// Places the active player's token on the selected square
        /// </summary>
        /// <param name="location">The PictureBox in the selected location</param>
        private void PlaceToken(PictureBox location)
        {
            SendMessage("", Color.Transparent);
            if (location.Image == null)
            {
                // Place token to visible grid
                if (activePlayer == Player.x)
                {
                    picActivePlayer.Image = oImg;
                    location.Image = xImg;
                }
                else
                {
                    picActivePlayer.Image = xImg;
                    location.Image = oImg;
                }

                // Update grid array to reflect the visible grid
                int col = int.Parse(location.Name.Substring(4, 1)) - 1;
                int row;
                switch (location.Name.Substring(3, 1))
                {
                    case "A":
                        row = 0;
                        break;
                    case "B":
                        row = 1;
                        break;
                    case "C":
                        row = 2;
                        break;
                    default:
                        row = -1;
                        break;
                }
                grid[row, col] = activePlayer;

                // If win or tie, display a message. Otherwise swap players and continue.
                if (CheckForWin())
                {
                    SendMessage($"Player {activePlayer.ToString().ToUpper()} wins!", Color.Green);
                    ResetGame();
                    return;
                }
                else if (GridIsFull())
                {
                    SendMessage($"It's a tie!", Color.Gray);
                    ResetGame();
                    return;
                }
                else
                {
                    if (activePlayer == Player.x)
                    {
                        activePlayer = Player.o;
                    }
                    else
                    {
                        activePlayer = Player.x;
                    }
                }
            }
            else
            {
                SendMessage("Location is not available", Color.Crimson);
            }
        }

        /// <summary>
        /// Checks all possible win conditions for the active player
        /// </summary>
        /// <returns>Whether or not the active player has won</returns>
        private bool CheckForWin()
        {
            for (int i = 0; i < SIZE_OF_GRID; i++)
            {
                if (grid[i, 0] == activePlayer && grid[i, 1] == activePlayer && grid[i, 2] == activePlayer)
                {
                    return true;
                }
            }
            for (int i = 0; i < SIZE_OF_GRID; i++)
            {
                if (grid[0, i] == activePlayer && grid[1, i] == activePlayer && grid[2, i] == activePlayer)
                {
                    return true;
                }
            }
            if (grid[1, 1] == activePlayer)
            {
                if (grid[0, 0] == activePlayer && grid[2, 2] == activePlayer)
                {
                    return true;
                }
                else if (grid[0, 2] == activePlayer && grid[2, 0] == activePlayer)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the visible grid is full
        /// </summary>
        /// <returns>Whether or not the grid is full</returns>
        private bool GridIsFull()
        {
            bool gridIsFull = true;
            foreach (PictureBox item in grpGrid.Controls)
            {
                if (item.Image == null)
                {
                    gridIsFull = false;
                }
            }
            return gridIsFull;
        }

        /// <summary>
        /// Resets the game to its inital state
        /// </summary>
        private void ResetGame()
        {
            foreach (PictureBox item in grpGrid.Controls)
            {
                item.Image = null;
            }
            grid = new Player[SIZE_OF_GRID, SIZE_OF_GRID];
            activePlayer = Player.x;
            picActivePlayer.Image = xImg;
        }

        private void picA1_Click(object sender, EventArgs e)
        {
            PlaceToken(picA1);
        }

        private void picA2_Click(object sender, EventArgs e)
        {
            PlaceToken(picA2);
        }

        private void picA3_Click(object sender, EventArgs e)
        {
            PlaceToken(picA3);
        }

        private void picB1_Click(object sender, EventArgs e)
        {
            PlaceToken(picB1);
        }

        private void picB2_Click(object sender, EventArgs e)
        {
            PlaceToken(picB2);
        }

        private void picB3_Click(object sender, EventArgs e)
        {
            PlaceToken(picB3);
        }

        private void picC1_Click(object sender, EventArgs e)
        {
            PlaceToken(picC1);
        }

        private void picC2_Click(object sender, EventArgs e)
        {
            PlaceToken(picC2);
        }

        private void picC3_Click(object sender, EventArgs e)
        {
            PlaceToken(picC3);
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            picActivePlayer.Image = xImg;
        }
    }
}
