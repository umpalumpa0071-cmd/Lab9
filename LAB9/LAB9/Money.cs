using System;

namespace LAB9
{
    public class Money
    {
        private uint rubles;
        private byte kopeks;

        public Money() : this(0, 0)
        {
        }

        public Money(uint rubles, byte kopeks)
        {
            this.rubles = rubles;
            this.kopeks = (byte)(kopeks % 100);
            this.rubles += (uint)(kopeks / 100);
        }

        public Money(Money other)
        {
            rubles = other.rubles;
            kopeks = other.kopeks;
        }

        public uint Rubles
        {
            get { return rubles; }
            set { rubles = value; }
        }

        public byte Kopeks
        {
            get { return kopeks; }
            set { kopeks = (byte)(value % 100); }
        }

        public Money AddKopeks(uint k)
        {
            uint total = rubles * 100 + kopeks + k;
            return new Money(total / 100, (byte)(total % 100));
        }

        public override string ToString()
        {
            return $"{rubles} руб. {kopeks} коп.";
        }

        public static Money operator ++(Money m)
        {
            return m.AddKopeks(1);
        }

        public static Money operator --(Money m)
        {
            uint total = m.rubles * 100 + m.kopeks;
            if (total > 0)
            {
                total--;
            }
            return new Money(total / 100, (byte)(total % 100));
        }

        public static explicit operator uint(Money m)
        {
            return m.rubles;
        }

        public static implicit operator double(Money m)
        {
            return m.kopeks / 100.0;
        }

        public static Money operator +(Money m, uint k)
        {
            return m.AddKopeks(k);
        }

        public static Money operator +(uint k, Money m)
        {
            return m.AddKopeks(k);
        }

        public static Money operator -(Money m, uint k)
        {
            uint total = m.rubles * 100 + m.kopeks;
            if (k > total)
            {
                total = 0;
            }
            else
            {
                total -= k;
            }
            return new Money(total / 100, (byte)(total % 100));
        }

        public static Money operator -(uint k, Money m)
        {
            uint total = m.rubles * 100 + m.kopeks;
            if (k < total)
            {
                total = 0;
            }
            else
            {
                total = k - total;
            }
            return new Money(total / 100, (byte)(total % 100));
        }
    }
}