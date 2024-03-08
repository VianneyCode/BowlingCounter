using BowlingCounter;
using BowlingCounter.GameManager;
using BowlingCounter.Interface;

var interfaceManager = new InterfaceManager();
var gameManager = new GameManager(interfaceManager);
var menuManager = new MenuManager(interfaceManager, gameManager);

menuManager.RunGame();