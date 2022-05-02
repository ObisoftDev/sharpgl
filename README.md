# sharpgl
Libreria OpenGL Para Desarrollo de Juegos Escrita En C#

# Ejemplo En Codigo

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using SharpGL;
    using SharpGL.Desktop;
    using SharpGL.Graphics;
    using SharpGL.Shapes

    namespace PixeliumTest
    {
        class EntryPoint
        {
            [STAThread]

            static void Main()
            {
                using (Game game = new Game())
                {
                    game.Run();
                }
            }

        }

        public class Game : RenderWindow
        {
            public override void OnLoad()
            {
                //TODO LOAD CODE
            }
            public override void OnUpdate(RenderLoop loop)
            {
            //TODO UPDATE CODE
            }
            public override void OnRender()
            {
                //TODO RENDER CODE
            }

            public override void OnResize(int w, int h)
            {
                GL.Viewport(0, 0, w, h);
            }
        }

    }
    
# Redes Sociales
Usuario En Telegram : https://t.me/obisoftdevel

Canal En Telegram : https://t.me/obisoft_dev

Youtube : https://m.youtube.com/channel/UCB1gH3rhENpWnsnxkA5Fl1Q/videos
