using API.DTOs;
using API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class DeviceControl
    {
		protected DataContext mcontext;

		public DeviceControl(DataContext context)
		{
			mcontext = context;
		}

		public List<object> GetAllDevice()
		{
			var result = new List<object>();

			try
			{
				var newtest = new Devices();
				var data = mcontext.Device.Select(p => new
				{
					p.id,
					p.name,
					p.status
				});


				result.AddRange(data);

				return result;

			}
			catch (Exception ex)
			{
				result.Add(ex);
				return result;
			}

		}

		public string GetDevice(int id)
		{

			try
			{
				var Host = mcontext.Device.Where(p => p.id == id).FirstOrDefault();

				if (Host.status == "true")
				{
					return "true";
				}

				else
				{
					return "false";
				}

			}
			catch (Exception ex)
			{
				return ex.Message + ex.InnerException + ex.Source + ex.HResult + ex.StackTrace + ex.HelpLink;
			}

		}

		public bool UpdateDeviceStatus(Devices newHostStatus)
		{
			try
			{
				var hostStatus = mcontext.Device.Where(p => p.id == newHostStatus.id).FirstOrDefault();
				hostStatus.status = newHostStatus.status;
				mcontext.Device.Update(hostStatus);
				mcontext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}

	}
}
