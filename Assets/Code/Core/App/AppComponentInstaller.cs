﻿using System;
using System.Collections.Generic;

namespace Code.Core.App {
	public class AppComponentInstaller {
		private static readonly Dictionary<string, object> _sources = new();
		
		public static T Add<T> (T instance) where T : class {
			_sources.Add(typeof(T).ToString(), instance);
			return instance;
		}
		
		public static T Resolve<T> () where T : class {
			if (!_sources.TryGetValue(typeof(T).ToString(), out var instance)) {
				throw new ArgumentException("Component not found");
			};
			
			return instance as T; 
		}
	}
}
