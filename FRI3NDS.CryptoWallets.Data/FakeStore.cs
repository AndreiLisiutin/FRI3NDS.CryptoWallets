using AutoMapper;
using FRI3NDS.CryptoWallets.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Data
{
	/// <summary>
	/// Хранилище объектов в памяти.
	/// </summary>
	/// <typeparam name="TBase">Базовый тип.</typeparam>
	/// <typeparam name="T">Тип представления.</typeparam>
	public class FakeStore<TBase, T>
		where T : class, TBase
		where TBase : class
	{
		/// <summary>
		/// Конструктор хранилища объектов в памяти.
		/// </summary>
		/// <param name="identifierName">Название поля-идентификатора. Если пусто, то {Название класса}Id.</param>
		public FakeStore(string identifierName = null)
		{
			this.Data = new List<T>();
			var className = typeof(T).Name;
			this.IdentifierName = identifierName ?? $"{className}Id";
			bool hasIdProperty = typeof(TBase).GetProperties().Any(e => e.Name == IdentifierName);
			Argument.Require(hasIdProperty, $"Не найдено свойство {IdentifierName} класса {className}.");
		}

		public List<T> Data { get; private set; }
		public string IdentifierName { get; private set; }

		/// <summary>
		/// Получить по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns></returns>
		public T GetById(Guid id)
		{
			return Data.FirstOrDefault(e => GetIdentifier(e) == id);
		}

		/// <summary>
		/// Получить список.
		/// </summary>
		/// <returns></returns>
		public List<T> Get()
		{
			return this.Data;
		}

		/// <summary>
		/// Сохранить.
		/// </summary>
		/// <param name="object">Что сохраняем.</param>
		/// <returns>Что-то сохраненное с Id.</returns>
		public TBase Save(TBase @object)
		{
			var foundObject = GetById(GetIdentifier(@object));
			T viewObject = default(T);
			if (foundObject == default(T))
			{
				Guid id = SetIdentifier(@object);
				viewObject = CloneObject<TBase, T>(@object);
				Data.Add(viewObject);
			}
			else
			{
				viewObject = CloneObject<TBase, T>(@object);
				Data.Remove(foundObject);
				Data.Add(viewObject);
			}
			return viewObject;
		}

		/// <summary>
		/// Удалить по ключу.
		/// </summary>
		/// <param name="id">Ключ.</param>
		public void Delete(Guid id)
		{
			var foundObject = GetById(id);
			if (foundObject != default(T))
			{
				Data.Remove(foundObject);
			}
		}

		private Guid GetIdentifier(TBase @object)
		{
			return (Guid)@object.GetType().GetProperty(IdentifierName).GetValue(@object, null);
		}

		private Guid SetIdentifier(TBase @object, Guid? identifier = null)
		{
			identifier = identifier ?? Guid.NewGuid();
			@object.GetType().GetProperty(IdentifierName).SetValue(@object, identifier, null);
			return identifier.Value;
		}

		private TOutput CloneObject<TInput, TOutput>(TInput input)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<TInput, TOutput>());
			IMapper mapper = config.CreateMapper();
			return mapper.Map<TOutput>(input);
		}
	}


	public class FakeStore<T> : FakeStore<T, T>
		where T : class
	{
		public FakeStore(string identifierName = null)
			: base(identifierName)
		{
		}
	}
}
