using FRI3NDS.CryptoWallets.Core.Models.Domain._Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Migrator.Migrator
{
	/// <summary>
	/// Компаратор версий БД.
	/// </summary>
	public interface IVersionComparer : IComparer<_Version>
	{
		/// <summary>
		/// Сериализовать номер версии.
		/// </summary>
		/// <param name="version">Номер версии в массиве.</param>
		/// <param name="separator">Разделитель чисел.</param>
		/// <returns>Номер версии для текста.</returns>
		string SerializeVersionNumber(int[] version, char separator = '.');

		/// <summary>
		/// Запарсить номер версии БД.
		/// </summary>
		/// <param name="version">Номер версии в формате ##.##.####.</param>
		/// <param name="separator">Разделитель чисел.</param>
		/// <returns>Массив чисел.</returns>
		int[] ParseVersionNumber(string version, char separator = '.');
	}
}
