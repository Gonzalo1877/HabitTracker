using HabitTracker.database;
using HabitTracker.menu;

var database = new DatabaseSQLite();
var menu = new Menu();

database.IniciarDb();
menu.MostrarMenu();