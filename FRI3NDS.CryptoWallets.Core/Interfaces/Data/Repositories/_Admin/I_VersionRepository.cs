﻿using FRI3NDS.CryptoWallets.Core.Models.Domain._Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRI3NDS.CryptoWallets.Core.Interfaces.Data.Repositories._Admin
{
	public interface I_VersionRepository
	{
		_Version GetById(int id);

		List<_Version> Query(
			int? id = null,
			string name = null,
			string scriptHash = null,
			int pageSize = 1000,
			int pageNumber = 0);

		_VersionBase Save(_VersionBase item);

		int Delete(int id);
	}
}
