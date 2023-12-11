

namespace AstroWars;
using AstroWars.Utilities;
using AstroWars.Collections;
using SDL2;


public sealed class Window : Disposable
{
    public Size                 Size            { get; }
    public string               Title           { get; }
    public nint                 Handle          { get; }
    public KeyboardState        KeyboardState   { get; } = new();
    

    private nint _renderer;
    public Window(Size size, string title)
    {
        Size          = size;
        Title         = title;
        KeyboardState = new();

        var result = SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
        if (result < 0) return;

        var handle = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, size.X, size.Y, SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
        if (handle == nint.Zero) return;

        _renderer = SDL.SDL_CreateRenderer(Handle, -1, SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);
        if (_renderer == nint.Zero) return;
    }




    private bool _quit;
    public bool IsOpen()
    {
        if (!_quit)
        {
            SDL.SDL_SetRenderDrawColor(_renderer, 0,0,0,0);
            SDL.SDL_RenderClear       (_renderer);
            SDL.SDL_RenderPresent     (_renderer);

            while (SDL.SDL_PollEvent(out var e) != 0)
            {
                switch (e.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        _quit = true;
                        break;
                    case SDL.SDL_EventType.SDL_KEYUP:
                        KeyboardState.Set((KeyboardCode)(int)e.key.keysym.sym, false);
                        break;
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        KeyboardState.Set((KeyboardCode)(int)e.key.keysym.sym, true);
                        break;
                }
            }

            return true;
        }
        return false;
    }
    public void Quit()
    {
        _quit = true;
    }
    
    
    protected override void OnDispose()
    {
        if (_renderer != nint.Zero) SDL.SDL_DestroyRenderer(_renderer);
        if (Handle != nint.Zero) SDL.SDL_DestroyWindow(Handle);
        SDL.SDL_Quit();
    }
} 