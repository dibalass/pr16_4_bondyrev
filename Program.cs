using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16_4
{
	class Program
	{
		static Hashtable catalog = new Hashtable();

		static void Main(string[] args)
		{
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nВыберите действие:\n" +
								  "1. Добавить диск\n" +
								  "2. Удалить диск\n" +
								  "3. Добавить песню на диск\n" +
								  "4. Удалить песню с диска\n" +
								  "5. Просмотреть содержимое каталога\n" +
								  "6. Просмотреть содержимое диска\n" +
								  "7. Поиск всех записей заданного исполнителя\n" +
								  "8. Выйти.");

				string choise = Console.ReadLine();

				switch (choise)
				{
					case "1": AddDisk(); break;
					case "2": DeleteDisk(); break;
					case "3": AddSong(); break;
					case "4": DeleteSong(); break;
					case "5": DisplayCatalog(); break;
					case "6": DisplayDisk(); break;
					case "7": SearchByArtist(); break;
					case "8": exit = true; break;
					default:
                        Console.WriteLine("Ошибка ввода");
					break;
				}

			}
		}

		private static void SearchByArtist()
		{
			Console.Clear();
			if (catalog.Count == 0)
				Console.WriteLine("Каталог пуст.");
			else
			{
				Console.Write("Введите имя исполнителя для поиска записей: ");
				string artistName = Console.ReadLine();
				bool found = false;
				int i = 0;

				foreach (ArrayList songs in catalog.Values)
				{
					foreach (string songName in songs)
					{
						if (songName.Contains(artistName))
						{
							Console.WriteLine($" {songName}");
							found = true; i++;
						}
					}
				}
				if (!found)
					Console.WriteLine("Записи исполнителя не найдены.");
			}
		}

		private static void DisplayDisk()
		{
			Console.Clear();
			if (catalog.Count == 0)
				Console.WriteLine("Каталог пуст.");
			else
			{
				Console.Write("Введите название диска для просмотра его содержимого: ");
				string diskName = Console.ReadLine();

				if (catalog.ContainsKey(diskName))
				{
					ArrayList songs = (ArrayList)catalog[diskName];

					if (songs.Count == 0)
						Console.WriteLine($"Содержимое диска `{diskName}` пустое.");
					else
					{
						Console.WriteLine($"Содержимое диска `{diskName}`: ");
						int i = 1;
						foreach (string songName in songs) 
						{ 
							Console.WriteLine($"{i} - {songName}"); 
							i++; 
						}
					}
				}
				else
					Console.WriteLine("Диска с таким именем не существует.");
			}
		}

		private static void DisplayCatalog()
		{
			Console.Clear();

			if (catalog.Keys.Count == 0)
				Console.WriteLine("Каталог пуст.");
			else
			{
				Console.WriteLine("Содержимое каталога:");

				int i = 1;
				foreach (string diskName in catalog.Keys) { Console.WriteLine($"{i}: {diskName}"); i++; }
			}
		}

		private static void DeleteSong()
		{
			Console.Clear();
			if (catalog.Count == 0)
				Console.WriteLine("Каталог пуст.");
			else
			{
				Console.Write("Введите название диска, с которого нужно удалить песню: ");
				string diskName = Console.ReadLine();

				if (catalog.Contains(diskName))
				{
					ArrayList songs = (ArrayList)catalog[diskName];

					if (songs.Count == 0)
						Console.WriteLine($"Диск `{diskName}` уже пустой.");
					else
					{
						Console.Write("Введите название песни: ");
						string songName = Console.ReadLine();

						if (songs.Contains(songName))
						{
							songs.Remove(songName);
							Console.WriteLine("Песня была удалена!");
						}
						else
							Console.WriteLine($"Песня с таким именем не существует на диске `{diskName}`.");
					}
				}
				else
					Console.WriteLine("Диска с таким именем не существует.");
			}
		}

		private static void AddSong()
		{
			Console.Clear();
			Console.Write("Введите название диска, на котором нужно добавить песню: ");
			string diskName = Console.ReadLine();

			if (catalog.ContainsKey(diskName))
			{
				ArrayList songs = (ArrayList)catalog[diskName];

				Console.Write("Введите название песни: ");
				string songName = Console.ReadLine();

				if (songs.Contains(songName))
					Console.WriteLine("Песня с таким именем уже существует на данном диске.");
				else
				{
					songs.Add(songName);
					Console.WriteLine("Песня была добавлена!");
				}
			}
			else
				Console.WriteLine("Диска с таким именем не существует.");
		}

		private static void DeleteDisk()
		{
			Console.Clear();
			if (catalog.Count == 0)
				Console.WriteLine("Каталог пуст.");
			else
			{
				Console.Write("Введите название диска для удаления: ");
				string diskName = Console.ReadLine();

				if (catalog.ContainsKey(diskName))
				{
					catalog.Remove(diskName);
					Console.WriteLine("Диск был удален!");
				}
				else
					Console.WriteLine("Диска с таким именем не существует.");
			}
		}

		private static void AddDisk()
		{
			Console.Clear();
			Console.Write("Введите название диска: ");
			string diskName = Console.ReadLine();

			if (catalog.ContainsKey(diskName))
				Console.WriteLine("Диск с таким именем уже существует.");
			else
			{
				catalog[diskName] = new ArrayList();
				Console.WriteLine("Диск был добавлен!");
			}
		}
	
	}
}
