using Microsoft.Extensions.Options;
using Nest;
using QI.Core.Common;
using QI.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QI.Core.ElasticSearch
{
    public interface IESFactory
    {
        Task<bool> Index<T>(T obj, string index_name) where T : class;
        Task<bool> Update<T>(T obj, string index_name) where T : class;
    }
    public class ESFactory : IESFactory
    {
        private readonly string esUrl = string.Empty;
        private ElasticClient elasticClient;
        public ESFactory(IOptions<AppConfigs> appConfigs)
        {
            esUrl = appConfigs.Value.ElasticUrl;
            ConnectAsync();
        }

        public void ConnectAsync()
        {
            var node = new Uri(esUrl);
            var settings = new ConnectionSettings(node);
            elasticClient = new ElasticClient(settings);
        }


        public async Task<bool> Index<T>(T obj, string index_name) where T : class
        {
            try
            {

                var response = await elasticClient.IndexAsync<T>(obj, idx => idx.Index(index_name));
                return response.IsValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update<T>(T obj, string index_name) where T : class
        {
            try
            {
                var response = await elasticClient.UpdateAsync<T>(obj, idx => idx.Index(index_name));
                return response.IsValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
