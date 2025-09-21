using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Brick_Breaker
{
    #region INTERFACE
    public interface GameView
    {
        Size ClientSize { get; } // Object returning the window size
        void Invalidate(); // Method to refresh the screen
        void Invoke(Action action); // Method that allows executing code in the main thread
    }
    public partial class Form1 : Form, GameView // Main class of the Form1 form implementing the interface
    {
        private Game game; // Game instance initialized when the game starts
        private MainMenu mainMenu; // Menu instance initialized when the program is launched

        void GameView.Invoke(Action action) // Method checking whether the code is executed in the main thread
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(action)); // If not, we pass the action to the main thread
            else
                action(); // If the code is executed in the main thread, we execute the action immediately
        }

        public Form1() // Form constructor:
        {
            InitializeComponent();
            InitializeMainMenu(); // Display the main menu
            InitializeForm(); // Configure the form's appearance
        }
        private void InitializeForm()
        {
            this.Text = "Brick Breaker";
            this.BackgroundImage = Properties.Resources.background;
            this.Size = new Size(821, 700);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false; // Fullscreen is not supported
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true; // Double buffering can smooth the movement of objects
            this.KeyPreview = true; // Allows intercepting key presses
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Add key event handlers
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
        }

        public void InitializeMainMenu() // Add the main menu
        {
            mainMenu = new MainMenu(this);
            this.Controls.Add(mainMenu);
        }

        public void ReturnToMainMenu() // Method called after the game ends
        {
            this.Controls.Clear(); // Remove any remnants of the game
            game = null; // Remove the game instance (it will be created anew)
            InitializeMainMenu(); // Display the menu
        }

        public void StartGame() // Start a new game
        {
            this.Controls.Clear(); // Remove the menu when the game starts
            game = new Game(this, isDemoMode: false); // Create a new game object
            game.Start(); // Start the game logic
            this.Focus(); // Set focus on the form to capture key inputs
        }
        public void StartDemo() // Similar to starting the game, but in demo mode we only pass the appropriate information to the game object
        {
            this.Controls.Clear();
            game = new Game(this, isDemoMode: true);
            game.Start();
            this.Focus();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) // Add key release event handling
        {
            game?.InputManager.HandleKeyUp(e.KeyCode); // Pass the information to the game class, which handles the event
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // Similarly, handle key press events
        {
            game?.InputManager.HandleKeyDown(e.KeyCode);
        }

        protected override void OnPaint(PaintEventArgs e) // Handle screen rendering
        {
            base.OnPaint(e); // Use the built-in base method
            game?.Renderer.Draw(e.Graphics); // Delegate the drawing to the game object
        }
    }
    public class MainMenu : Panel // Create the main menu
    {
        // Create buttons, a label, and a reference to Form1
        private Button startButton;
        private Button demoButton;
        private Button exitButton;
        private Label titleLabel;
        private Form1 form;
        private FontFamily fontFamily;

        public MainMenu(Form1 parentForm) // Main class of the main menu
        {
            form = parentForm; // Instance of Form1
            this.BackColor = Color.Transparent; // Background – transparent (taken from Form1)
            this.Size = parentForm.ClientSize; // Read the window size from Form1
            this.Dock = DockStyle.Fill; // Place the menu across the entire form area

            LoadCustomFont(); // Load a font from a private resource so the user does not have to install it
            InitializeMenu(); // Initialize the entire menu
        }

        private void LoadCustomFont() // Method allowing the use of a font from project files
        {
            string fontPath = Path.Combine(Application.StartupPath, "A Goblin Appears!.otf");
            if (File.Exists(fontPath)) // Check if the path exists
            {
                PrivateFontCollection fontCollection = new PrivateFontCollection();
                fontCollection.AddFontFile(fontPath);
                fontFamily = fontCollection.Families[0];
            }
            else
            {
                MessageBox.Show("Font didn't load properly"); // If it doesn't exist, show a message
            }
        }

        // Create a method for generating all buttons to separate this logic from the rest of the code and make it cleaner
        private Button CreateButton(string text, Image backgroundImage, int width, int height, int x, int y, EventHandler onClick)
        {
            Button button = new Button
            {
                Text = text,
                Font = new Font(fontFamily, 12, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(width, height),
                Location = new Point(x, y),
                BackgroundImage = backgroundImage,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += onClick; // Add event handling for button clicks

            return button;
        }
        private void InitializeMenu() // Initialize buttons, create a label, and handle individual events
        {
            // Calculate the ideal starting positions for the created buttons on the X and Y axes to keep everything centered
            int buttonWidth = 170, buttonHeight = 70, gap = 12, labelHeight = 150, labelWidth = 600;
            int totalHeight = labelHeight + buttonHeight * 2 + gap * 4;
            int startY = (int)((this.ClientSize.Height - totalHeight) / 2.5);
            int buttonStartX = (this.ClientSize.Width - buttonWidth - gap) / 2;
            int buttonStartY = startY + labelHeight + gap * 2;

            // Create the title label
            titleLabel = new Label
            {
                Text = "Brick Breaker",
                Font = fontFamily != null ? new Font(fontFamily, 48, FontStyle.Regular) : new Font("Arial", 10, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 32, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(labelWidth, labelHeight),
                Location = new Point((this.ClientSize.Width - labelWidth) / 2, startY)
            };
            this.Controls.Add(titleLabel);

            // Create the buttons
            startButton = CreateButton("Start", Properties.Resources.pinkBrick, buttonWidth, buttonHeight,
                buttonStartX, buttonStartY, (sender, e) =>
                {
                    form.Invoke(new MethodInvoker(() => form.StartGame())); // When "Start" is clicked, the StartGame method from Form1 is executed
                });

            demoButton = CreateButton("Demo", Properties.Resources.orangeBrick, buttonWidth, buttonHeight,
                buttonStartX, buttonStartY + buttonHeight + gap, (sender, e) =>
                {
                    form.Invoke(new MethodInvoker(() => form.StartDemo())); // Similarly, "Demo" launches the demo mode
                });

            exitButton = CreateButton("Exit", Properties.Resources.greenBrick, buttonWidth, buttonHeight,
                buttonStartX, buttonStartY + (buttonHeight + gap) * 2, (sender, e) =>
                {
                    form.Invoke(new MethodInvoker(() => form.Close())); // The "Exit" button closes the application
                });

            // Add the buttons to the panel
            this.Controls.Add(startButton);
            this.Controls.Add(demoButton);
            this.Controls.Add(exitButton);
        }
    }
    #endregion
    #region GAME LOGIC
    public class Game // Class responsible for game logic
    {
        // Events handling game over and game won scenarios
        public event Action gameOver;
        public event Action gameWon;
        public bool isStarted { get; private set; } // Variable indicating whether the game session is active

        // Game objects
        public Ball ball { get; set; }
        public Paddle paddle { get; set; }
        public List<Brick> bricks { get; set; }

        private Timer timer; // Timer controlling the game
                             // References to the interface and form
        private GameView view;
        private Form1 form;
        private Random randomizer = new Random(); // Random number generator

        // Variables indicating different game states/modes
        private bool isGameOver = false;
        private bool isGameWon = false;
        private bool isDemoMode = false;

        // List of brick images in different colors (randomly chosen each time)
        private Image[] brickImages = new Image[]
        {
        Properties.Resources.pinkBrick,
        Properties.Resources.blueBrick,
        Properties.Resources.orangeBrick,
        Properties.Resources.greenBrick
        };

        // References to objects managing collisions, rendering, and input
        public CollisionManager CollisionManager { get; private set; }
        public Renderer Renderer { get; private set; }
        public InputManager InputManager { get; private set; }

        public Game(GameView view, bool isDemoMode) // Game constructor accepting a view and game mode
        {
            this.view = view; // Assign the interface

            // Try to cast the view to Form1; if it fails, throw an exception
            this.form = view as Form1 ?? throw new ArgumentException("IGameView must be of type Form1");

            this.isDemoMode = isDemoMode; // Set demo mode
            bricks = new List<Brick>(); // Initialize the brick list
            timer = new Timer { Interval = 16 }; // Set the timer interval
            timer.Tick += Timer_Tick; // Add the Tick event handler to the timer
            isStarted = false; // Initially, the game is flagged as not started

            gameOver += OnGameOver;
            gameWon += OnGameWon;

            // Initialize objects managing collisions, rendering, and input
            CollisionManager = new CollisionManager(this);
            Renderer = new Renderer(this);
            InputManager = new InputManager(this);
        }
        public void Start() // Class method that starts the gameplay
        {
            if (!isStarted) // Check if the session has not already started
            {
                // Randomly select initial velocities on the axes
                int startVelocityX = randomizer.Next(-5, 6);
                int startVelocityY = -randomizer.Next(4, 12);

                // Create (initialize) the main game objects
                ball = new Ball((view.ClientSize.Width / 2) - 11, view.ClientSize.Height - 85, 26, Properties.Resources.ball);
                paddle = new Paddle((view.ClientSize.Width / 2) - (134 / 2), view.ClientSize.Height - 50, 134, 20, Properties.Resources.paddle, isDemoMode);
                CreateBricks(); // Create the bricks

                timer.Start();
                isStarted = true; // The game has been started
            }
        }

        private void Timer_Tick(object sender, EventArgs e) // Timer actions
        {
            ball.Move(); // Handle the ball's movement

            if (isDemoMode)
                InputManager.HandleDemoMovement(); // If demo mode is active, use the automated paddle movement

            paddle.Move(); // Handle the paddle's movement
            CollisionManager.CheckCollisions(); // Check collisions
            GameLostCheck(); // Verify if the game is lost
            GameWonCheck(); // Verify if the game is won
            view.Invalidate(); // Refresh the game view
        }

        private void CreateBricks() // Method to create bricks on the form
        {
            bricks.Clear(); // Ensure no unwanted bricks remain

            // Calculate the total width and height of the brick layout
            int totalBricksWidth = (8 * GameConstants.brickWidth) + (7 * 5);
            int totalBricksHeight = (8 * GameConstants.brickHeight) + (7 * 5);

            // Calculate left and top margins to center the bricks
            int brickLeft = (view.ClientSize.Width - totalBricksWidth) / 2;
            int brickTop = (view.ClientSize.Height - totalBricksHeight) / 10;

            for (int row = 0; row < 8; row++) // Iterate through rows and columns
            {
                for (int col = 0; col < 8; col++)
                {
                    int x = brickLeft + col * (85 + 5); // Calculate brick position
                    int y = brickTop + row * (35 + 5);

                    // Create a new brick, randomly selecting one of the four images
                    Brick newBrick = new Brick(x, y, 85, 35, brickImages);
                    bricks.Add(newBrick);
                }
            }
        }
        private void GameLostCheck() // Method checking if the ball has left the bottom boundary of the form
        {
            if (ball.y >= view.ClientSize.Height)
            {
                EndGame(); // Stop the game
                gameOver?.Invoke(); // Trigger the game over event
            }
        }

        private void GameWonCheck() // Method checking if all bricks have been destroyed (game won)
        {
            if (bricks.All(b => b.isDestroyed))
            {
                EndGame(); // Stop the game
                gameWon?.Invoke(); // Trigger the game won event
            }
        }

        public void EndGame()
        {
            timer.Stop(); // Stop the timer
            isStarted = false; // Set the game as not running
        }

        private void OnGameOver() // Method handling the game over event
        {
            if (isGameOver) return; // Prevent multiple calls
            isGameOver = true;

            DialogResult userDecision = MessageBox.Show( // Show a message about losing the game
                "Game Over\nDo you want to play again?", // Ask if the user wants to play again
                "Game Over",
                MessageBoxButtons.YesNo
            );

            if (userDecision == DialogResult.Yes) // If yes:
            {
                Start();  // Restart the game
                isGameOver = false; // Reset the flag
            }
            else // If no, return to the main menu
            {
                view.Invoke(new Action(form.ReturnToMainMenu));
                isGameOver = false;
            }
        }

        private void OnGameWon() // Method handling the game won event or demo completion
        {
            if (isGameWon) return; // Prevent multiple calls
            isGameWon = true;

            string message = isDemoMode ? // Similar to the game over case
                "Demo Complete - The demo succeeded. Would you like to run it again?" :
                "Congratulations! You won the game. Would you like to play again?";
            string caption = isDemoMode ? "Demo Complete" : "Congratulations!";

            DialogResult userDecision = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

            if (userDecision == DialogResult.Yes)
            {
                Start();  // Restart the game
                isGameWon = false;
            }
            else
            {
                view.Invoke(new Action(form.ReturnToMainMenu));
                isGameWon = false;
            }
        }
    }
    public class CollisionManager // Class handling collisions
    {
        private readonly Game game; // Reference to the game object

        public CollisionManager(Game game)
        {
            this.game = game;
        }

        public void CheckCollisions()
        {
            // Ball-paddle collision, considering three conditions:
            if (game.ball.y + game.ball.height >= game.paddle.y &&
                game.ball.x + game.ball.width >= game.paddle.x &&
                game.ball.x <= game.paddle.x + game.paddle.width)
            {
                game.ball.Bounce(); // Bounce the ball off the paddle
            }

            // Ball-brick collisions. Iterate through all bricks and check for collisions with the ball
            foreach (var brick in game.bricks)
            {
                if (!brick.isDestroyed &&
                    game.ball.x + game.ball.width > brick.x &&
                    game.ball.x < brick.x + brick.width &&
                    game.ball.y + game.ball.height > brick.y &&
                    game.ball.y < brick.y + brick.height)
                {
                    game.ball.Bounce(); // Bounce the ball off the brick
                    brick.Destroy(); // Destroy the brick
                }
            }
        }
    }
    public class Renderer // Class responsible for drawing game objects on the screen
    {
        private readonly Game game; // Standard reference

        public Renderer(Game game)
        {
            this.game = game;
        }

        public void Draw(Graphics g) // Draw the already initialized game objects
        {
            game.ball.Draw(g);
            game.paddle.Draw(g);
            foreach (var brick in game.bricks)
            {
                brick.Draw(g);
            }
        }
    }

    public class InputManager // Class handling keyboard input
    {
        private readonly Game game; // Reference

        public InputManager(Game game)
        {
            this.game = game;
        }

        public void HandleKeyDown(Keys key)
        {
            if (!game.isStarted) return; // Do not process keyboard input when the game is not active

            if (key == Keys.Left)
                game.paddle.SetVelocity(-GameConstants.paddleSpeed); // Paddle speed left
            else if (key == Keys.Right)
                game.paddle.SetVelocity(GameConstants.paddleSpeed); // Paddle speed right
        }

        public void HandleKeyUp(Keys key) // Similarly for key release
        {
            if (!game.isStarted) return;

            if (key == Keys.Left || key == Keys.Right)
                game.paddle.SetVelocity(0);
        }

        public void HandleDemoMovement() // Handles demo mode where the paddle follows the ball along the X axis
        {
            int demoSpeed = GameConstants.paddleSpeed - 3; // Paddle speed in demo mode (slightly slower)
            int paddleCenter = game.paddle.x + game.paddle.width / 2;
            int ballCenter = game.ball.x + game.ball.width / 2;

            if (paddleCenter < ballCenter - 5)
                game.paddle.SetVelocity(demoSpeed); // If paddle center is left of the ball, move paddle right
            else if (paddleCenter > ballCenter + 5)
                game.paddle.SetVelocity(-demoSpeed); // If paddle center is right of the ball, move paddle left
            else
                game.paddle.SetVelocity(0); // If paddle center aligns with ball center, stop the paddle
        }
    }
    #endregion
    #region GAME OBJECTS
    public static class GameConstants // Class containing constant values used in other classes, such as object dimensions or speed
    {
        // Brick dimensions
        public const int brickWidth = 85;
        public const int brickHeight = 35;
        public const int brickGap = 5;

        // Number of bricks per row and column
        public const int brickRows = 8;
        public const int brickColumns = 8;

        // Ball speeds
        public const int ballMinSpeed = 5;
        public const int ballMaxSpeed = 7;

        // Paddle speed
        public const int paddleSpeed = 10;
    }

    public abstract class GameObject // Base class for all objects, defining their basic properties
    {
        public int x { get; set; } // X position
        public int y { get; set; } // Y position
        public int width { get; set; } // Object width
        public int height { get; set; } // Object height
        public Image objectImage { get; set; } // Object image

        // Default form boundaries
        public static int boundaryWidth { get; set; } = 821;
        public static int boundaryHeight { get; set; } = 700;

        public GameObject(int x, int y, int width, int height, Image image)
        {
            this.x = x; // Set X position
            this.y = y; // Set Y position
            this.width = width; // Set width
            this.height = height; // Set height
            objectImage = image; // Set image
        }

        public abstract void Move(); // Abstract Move method, each object has its own logic here

        public virtual void Draw(Graphics g) // Method checks if the object has an assigned image and draws it
        {
            if (objectImage != null)
            {
                g.DrawImage(objectImage, new Rectangle(x, y, width, height));
            }
        }
    }
    public class Ball : GameObject // Ball class inheriting from the base GameObject class
    {
        // Fields storing the ball's velocity on each axis
        private int velocityX;
        private int velocityY;
        private static Random randomizer = new Random(); // Random number generator to vary ball speed (game dynamics)

        // Ball constructor
        public Ball(int x, int y, int diameter, Image image)
            : base(x, y, diameter, diameter, image)
        {
            velocityX = randomizer.Next(5, 7) * (randomizer.Next(2) == 0 ? 1 : -1);
            velocityY = randomizer.Next(5, 7) * (randomizer.Next(2) == 0 ? 1 : -1);
        }

        public override void Move() // Implementation of ball movement
        {
            // Update ball position based on velocity
            x += velocityX;
            y += velocityY;

            // Check for collisions with the walls
            if (x <= 0 || x + width >= GameObject.boundaryWidth)
            {
                velocityX *= -1; // Bounce off the left or right wall, reversing the ball's direction
            }
            if (y <= 0)  // Bounce off the top boundary has the same effect
            {
                velocityY *= -1;
            }
        }

        public void Bounce() // Method reverses the vertical direction, used when colliding with the paddle or bricks
        {
            velocityY *= -1;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g); // Calls the Draw method from the base class
        }
    }
    public class Paddle : GameObject // Class representing the paddle, also inherits from the base class
    {
        // Variables used for smooth velocity transitions
        private float currentVelocity;
        private float targetVelocity;
        private readonly bool isDemo;

        public Paddle(int x, int y, int width, int height, Image image, bool isDemo) // Paddle constructor
            : base(x, y, width, height, image)
        {
            this.isDemo = isDemo;
            // Initially, velocities are set to zero (they will change later)
            currentVelocity = 0;
            targetVelocity = 0;
        }

        public void SetVelocity(int velocity) // Method sets the target velocity of the paddle
        {
            targetVelocity = velocity;
        }

        public override void Move() // Implementation of paddle movement
        {
            currentVelocity += (targetVelocity - currentVelocity) * 0.2f;
            x += (int)currentVelocity;

            // Prevent the paddle from going beyond the left boundary
            if (x < 0)
                x = 0;

            // Prevent the paddle from going beyond the right boundary
            if (x + width > GameObject.boundaryWidth)
                x = GameObject.boundaryWidth - width;
        }

        public override void Draw(Graphics g) // Draw using the base method
        {
            base.Draw(g);
        }
    }
    public class Brick : GameObject // Class responsible for bricks
    {
        public bool isDestroyed { get; private set; } // Variable indicating whether the brick has been destroyed
        private static Random randomizer = new Random(); // Random number generator for selecting the brick's color (image)

        // Constructor
        public Brick(int x, int y, int width, int height, Image[] images)
            : base(x, y, width, height, images[randomizer.Next(images.Length)])
        {
            isDestroyed = false; // Initially, the brick is not destroyed
        }

        public override void Move()
        {
            // No implementation – bricks do not move
        }

        public override void Draw(Graphics g) // Draw the brick
        {
            if (!isDestroyed)
            {
                base.Draw(g); // Calls the Draw method from the base class
            }
        }

        public void Destroy()
        {
            isDestroyed = true; // Mark the brick as destroyed
        }
    }
    #endregion
}
