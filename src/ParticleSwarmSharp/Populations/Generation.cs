﻿using ParticleSwarmSharp.Particles;

namespace ParticleSwarmSharp.Populations
{
    public class Generation
    {
        public Generation(int number, IEnumerable<IParticle> particles)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (particles == null || !particles.Any())
            {
                throw new ArgumentNullException(nameof(particles));
            }

            Number = number;
            CreatedAt = DateTime.Now;
            Particles = particles;
        }

        public int Number { get; private set; }

        public DateTime CreatedAt { get; internal set; }

        public IEnumerable<IParticle> Particles { get; internal set; }

        public IParticle? BestParticle { get; internal set; }

        public void End()
        {
            Particles = Particles.OrderByDescending(x => x.Fitness.Value);

            BestParticle = Particles.First();
        }
    }
}