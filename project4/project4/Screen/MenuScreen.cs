using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project4.Screen
{
    public enum MenuState
    {
        Main, 
        Help
    }
    class MenuScreen
    {
        List<Text> menuEntries, helpText;
        MenuState mState = MenuState.Main;
        int selection;
        public MenuScreen()
        {
            selection = 0;

            #region Menu Items
            menuEntries = new List<Text>();
            menuEntries.Add(new Text("play game", new Vector2(30, 80)));
            menuEntries.Add(new Text("Help", new Vector2(30, menuEntries[0].Position.Y + 5.0f)));
            menuEntries.Add(new Text("Quit", new Vector2(30, menuEntries[1].Position.Y + 5.0f)));
            #endregion
            #region Help Items
            helpText = new List<Text>();
            helpText.Add(new Text("Help", new Vector2(30,80)));
            #endregion

        }
        public void Update(GameTime gameTime)
        {
            #region Main

            #endregion
            #region Help

            #endregion
        }
        public void Draw()
        {
            #region Main
            #endregion
            #region Help
            #endregion

        }
    }
}
