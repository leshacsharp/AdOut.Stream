/* 
 * AdOut.Planning API
 *
 * Access to Apps API
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp.Portable;
using AdOut.Stream.Planning.Client.Client;
using AdOut.Stream.Planning.Client.Model;

namespace AdOut.Stream.Planning.Client.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public interface IPlanAdApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns></returns>
        void PlanAdDelete (string planId, string adId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PlanAdDeleteWithHttpInfo (string planId, string adId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns></returns>
        void PlanAdPost (string planId, string adId, decimal? order = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PlanAdPostWithHttpInfo (string planId, string adId, decimal? order = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns></returns>
        void PlanAdPut (string planId, string adId, int? order = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> PlanAdPutWithHttpInfo (string planId, string adId, int? order = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PlanAdDeleteAsync (string planId, string adId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdDeleteAsyncWithHttpInfo (string planId, string adId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PlanAdPostAsync (string planId, string adId, decimal? order = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdPostAsyncWithHttpInfo (string planId, string adId, decimal? order = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PlanAdPutAsync (string planId, string adId, int? order = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdPutAsyncWithHttpInfo (string planId, string adId, int? order = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
        public partial class PlanAdApi : IPlanAdApi
    {
        private AdOut.Stream.Planning.Client.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanAdApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PlanAdApi(String basePath)
        {
            this.Configuration = new AdOut.Stream.Planning.Client.Client.Configuration { BasePath = basePath };

            ExceptionFactory = AdOut.Stream.Planning.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanAdApi"/> class
        /// </summary>
        /// <returns></returns>
        public PlanAdApi()
        {
            this.Configuration = AdOut.Stream.Planning.Client.Client.Configuration.Default;

            ExceptionFactory = AdOut.Stream.Planning.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanAdApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public PlanAdApi(AdOut.Stream.Planning.Client.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = AdOut.Stream.Planning.Client.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = AdOut.Stream.Planning.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public AdOut.Stream.Planning.Client.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public AdOut.Stream.Planning.Client.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns></returns>
        public void PlanAdDelete (string planId, string adId)
        {
             PlanAdDeleteWithHttpInfo(planId, adId);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> PlanAdDeleteWithHttpInfo (string planId, string adId)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdDelete");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdDelete");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PlanAdDeleteAsync (string planId, string adId)
        {
             await PlanAdDeleteAsyncWithHttpInfo(planId, adId);

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdDeleteAsyncWithHttpInfo (string planId, string adId)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdDelete");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdDelete");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdDelete", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns></returns>
        public void PlanAdPost (string planId, string adId, decimal? order = null)
        {
             PlanAdPostWithHttpInfo(planId, adId, order);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> PlanAdPostWithHttpInfo (string planId, string adId, decimal? order = null)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdPost");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdPost");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter
            if (order != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "order", order)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PlanAdPostAsync (string planId, string adId, decimal? order = null)
        {
             await PlanAdPostAsyncWithHttpInfo(planId, adId, order);

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdPostAsyncWithHttpInfo (string planId, string adId, decimal? order = null)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdPost");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdPost");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter
            if (order != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "order", order)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns></returns>
        public void PlanAdPut (string planId, string adId, int? order = null)
        {
             PlanAdPutWithHttpInfo(planId, adId, order);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> PlanAdPutWithHttpInfo (string planId, string adId, int? order = null)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdPut");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdPut");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter
            if (order != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "order", order)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task PlanAdPutAsync (string planId, string adId, int? order = null)
        {
             await PlanAdPutAsyncWithHttpInfo(planId, adId, order);

        }

        /// <summary>
        ///  
        /// </summary>
        /// <exception cref="AdOut.Stream.Planning.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="planId"></param>
        /// <param name="adId"></param>
        /// <param name="order"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> PlanAdPutAsyncWithHttpInfo (string planId, string adId, int? order = null)
        {
            // verify the required parameter 'planId' is set
            if (planId == null)
                throw new ApiException(400, "Missing required parameter 'planId' when calling PlanAdApi->PlanAdPut");
            // verify the required parameter 'adId' is set
            if (adId == null)
                throw new ApiException(400, "Missing required parameter 'adId' when calling PlanAdApi->PlanAdPut");

            var localVarPath = "./plan-ad";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (planId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "planId", planId)); // query parameter
            if (adId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "adId", adId)); // query parameter
            if (order != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "order", order)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PlanAdPut", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Key, x => string.Join(",", x.Value)),
                null);
        }

    }
}
