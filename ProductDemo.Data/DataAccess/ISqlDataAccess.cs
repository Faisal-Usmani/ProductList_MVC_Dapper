﻿namespace ProductDemo.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(String spName, T parameters, string connectionId = "DefaultConnection");
    }
}