using Boids.Boids;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Boids {
	public class MainGame : Game 
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public static int screenWidth = 1920;
		public static int screenHeight = 1080;

		Flock flock;
		public MainGame() 
		{
			graphics = new GraphicsDeviceManager(this);

			graphics.PreferredBackBufferWidth = screenWidth;
			graphics.PreferredBackBufferHeight = screenHeight;
			graphics.IsFullScreen = true;
			graphics.ApplyChanges();
		}

		protected override void Initialize() 
		{
			base.Initialize();

			flock = new Flock();
		}

		protected override void LoadContent() 
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Boid.boidSprite = Content.Load<Texture2D>("Content/Boid");
		}

		protected override void UnloadContent() 
		{
			spriteBatch.Dispose();
		}

		protected override void Update(GameTime gameTime) 
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);

			flock.Update();
		}

		protected override void Draw(GameTime gameTime) 
		{
			GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);

			spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			flock.Draw(spriteBatch);

			spriteBatch.End();
		}
	}
}
