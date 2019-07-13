using FlushTheToiletClient.Models;
using FlushTheToiletClient.RestApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FlushTheToiletClient.Services
{
    public class FlushTheToiletWebClientAccess
    {
        private const string FLUSHER_MOTOR_URI = "/api/v1/FlusherMotor";
        private const string MAN_DETECTION_URI = "/api/v1/ManDetection";
        private const string TOILET_STATE_MACHINE_URI = "/api/v1/FlusherStateMachine";
        private const string LED_ON_URI = "/api/v1/Led/on";
        private const string LED_OFF_URI = "/api/v1/Led/off";

        private HttpClient mHttpclient;

        public FlushTheToiletWebClientAccess()
        {
            mHttpclient = new HttpClient();
            var uri = $"http://piattoilet:5000";
            mHttpclient.BaseAddress = new Uri(uri);
            mHttpclient.DefaultRequestHeaders.Accept.Clear();
            mHttpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void MotorForwardAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("forward");
                var response = mHttpclient.PutAsync(FLUSHER_MOTOR_URI, inputMessage.Content).Result;
            }
            catch (Exception ex)
            {

            }
        }

        public async void MotorBackwardAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("backward");
                var response = await mHttpclient.PutAsync(FLUSHER_MOTOR_URI, inputMessage.Content);
            }
            catch (Exception ex)
            {

            }
        }

        public async void MotorStopAsync()
        {
            try
            {

                var inputMessage = CreateHttpRequestMessage("stop");
                var response = await mHttpclient.PutAsync(FLUSHER_MOTOR_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch(Exception ex)
            {

            }
        }

        public double GetDistance()
        {
            double retVal = 0.0;
            
            try
            {
                var response = mHttpclient.GetAsync(MAN_DETECTION_URI).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    var serializedResult = JsonConvert.DeserializeObject<DistanceDTO>(responseText);
                    retVal = serializedResult.Distance;
                }
            }
            catch (Exception ex)
            {

            }

            return retVal;
        }

        public async void StartFlusherStateMachine()
        {
            try
            {

                var inputMessage = CreateHttpRequestMessage("start");
                var response = await mHttpclient.PutAsync(TOILET_STATE_MACHINE_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void StopFlusherStateMachine()
        {
            try
            {

                var inputMessage = CreateHttpRequestMessage("stop");
                var response = await mHttpclient.PutAsync(TOILET_STATE_MACHINE_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public FlusherStateMachineStatusModel GetFlusherStateMachineStatus()
        {
            FlusherStateMachineStatusModel retVal = new FlusherStateMachineStatusModel();
            try
            {
                var response = mHttpclient.GetAsync(TOILET_STATE_MACHINE_URI).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    var serializedResult = JsonConvert.DeserializeObject<FlusherStateMachineStatusDTO>(responseText);
                    retVal.CurrentState = serializedResult.CurrentState;
                    retVal.Distance = serializedResult.Distance;
                    retVal.IsInAutomaticMode = serializedResult.IsInAutomaticMode;
                }
            }
            catch (Exception ex)
            {

            }

            return retVal;
        }

        public async void AllLedsOnAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("all");
                var response = await mHttpclient.PutAsync(LED_ON_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedRedOnAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("red");
                var response = await mHttpclient.PutAsync(LED_ON_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedYellowOnAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("yellow");
                var response = await mHttpclient.PutAsync(LED_ON_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedGreenOnAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("green");
                var response = await mHttpclient.PutAsync(LED_ON_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void AllLedsOffAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("all");
                var response = await mHttpclient.PutAsync(LED_OFF_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedRedOffAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("red");
                var response = await mHttpclient.PutAsync(LED_OFF_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedYellowOffAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("yellow");
                var response = await mHttpclient.PutAsync(LED_OFF_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void LedGreenOffAsync()
        {
            try
            {
                var inputMessage = CreateHttpRequestMessage("green");
                var response = await mHttpclient.PutAsync(LED_OFF_URI, inputMessage.Content);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        private HttpRequestMessage CreateHttpRequestMessage(string content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            return httpRequestMessage;
        }
    }
}
