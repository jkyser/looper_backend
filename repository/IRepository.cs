using Loopr.audioDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loopr.repository
{
    public interface IRepository
    {
        public void Save(AudioFile audioFile);
        public List<AudioFile> GetAll();
        public AudioFile Get(int id);
        public void Delete(int id);
    }
}
