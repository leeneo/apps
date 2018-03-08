using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CcMis.Models
{
    public partial class newhotel_xyjdContext : DbContext
    {
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<HistoryGuest> HistoryGuest { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Parametre> Parametre { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<RegisterNorate> RegisterNorate { get; set; }
        public virtual DbSet<RoomState> RoomState { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<TRoomSign> TRoomSign { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=newhotel_xyjd;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.SNo);

                entity.ToTable("guest");

                entity.Property(e => e.SNo)
                    .HasColumnName("s_no")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SFinGuest)
                    .HasColumnName("S_FIN_GUEST")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SGroup)
                    .HasColumnName("s_group")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SGuest)
                    .HasColumnName("s_guest")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SName)
                    .HasColumnName("s_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistoryGuest>(entity =>
            {
                entity.HasKey(e => e.SAccountNo);

                entity.ToTable("history_guest");

                entity.HasIndex(e => e.DOutDate)
                    .HasName("idx_history_guest_d_out_date");

                entity.HasIndex(e => new { e.DArriveWorkdate, e.DDepartWorkdate })
                    .HasName("idx_history_guest_d_arrive_workdate");

                entity.Property(e => e.SAccountNo)
                    .HasColumnName("s_account_no")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdCompany)
                    .HasColumnName("ad_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Authorize)
                    .HasColumnName("authorize")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Bar)
                    .HasColumnName("bar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Breakfast)
                    .HasColumnName("breakfast")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CIsTurn)
                    .HasColumnName("c_is_turn")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CServe)
                    .HasColumnName("c_serve")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CSex)
                    .HasColumnName("c_sex")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CompAcct)
                    .HasColumnName("comp_acct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.CtDept)
                    .HasColumnName("CT_Dept")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveDate)
                    .HasColumnName("d_arrive_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveWorkdate)
                    .HasColumnName("d_arrive_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DBirthday)
                    .HasColumnName("d_birthday")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DCheckoutDate)
                    .HasColumnName("d_checkout_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDaishou)
                    .HasColumnName("d_daishou")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DDepartDate)
                    .HasColumnName("d_depart_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DDepartWorkdate)
                    .HasColumnName("d_depart_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DHotelDate)
                    .HasColumnName("d_hotel_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DOutDate)
                    .HasColumnName("d_out_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DSaunaTotcharge)
                    .HasColumnName("d_sauna_totcharge")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DSetDate)
                    .HasColumnName("d_set_date")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Daysin).HasColumnName("daysin");

                entity.Property(e => e.DelayCode)
                    .HasColumnName("delay_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.DelayEmp)
                    .HasColumnName("delay_emp")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DiscPerson)
                    .HasColumnName("disc_person")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Event)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinDate)
                    .HasColumnName("fin_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.GtosMark)
                    .HasColumnName("gtos_mark")
                    .HasColumnType("char(30)");

                entity.Property(e => e.GtosMss)
                    .HasColumnName("gtos_mss")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Gtype)
                    .HasColumnName("gtype")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GtypeCode)
                    .HasColumnName("gtype_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.GuestNote)
                    .HasColumnName("guest_note")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LateDate)
                    .HasColumnName("late_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.LateDays).HasColumnName("late_days");

                entity.Property(e => e.LateTime)
                    .HasColumnName("late_time")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Marks)
                    .HasColumnName("marks")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NBalance)
                    .HasColumnName("n_balance")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.NCharge)
                    .HasColumnName("n_charge")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.NCount).HasColumnName("n_count");

                entity.Property(e => e.NFactRate)
                    .HasColumnName("n_fact_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NGuest).HasColumnName("n_guest");

                entity.Property(e => e.NPay)
                    .HasColumnName("n_pay")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.NSaunaChg)
                    .HasColumnName("n_sauna_chg")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.NServe)
                    .HasColumnName("n_serve")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NStandRate)
                    .HasColumnName("n_stand_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NTax)
                    .HasColumnName("n_tax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OSize)
                    .HasColumnName("o_size")
                    .HasColumnType("char(2)");

                entity.Property(e => e.OrgDate)
                    .HasColumnName("org_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.OriType)
                    .HasColumnName("ori_type")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Pl)
                    .HasColumnName("pl")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCode)
                    .HasColumnName("price_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.RateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RecordCode)
                    .HasColumnName("record_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Resvnid)
                    .HasColumnName("resvnid")
                    .HasColumnType("numeric(12, 0)");

                entity.Property(e => e.SCardType)
                    .HasColumnName("s_card_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SCheckOut)
                    .HasColumnName("s_check_out")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SCheckout)
                    .HasColumnName("s_checkout")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SClass)
                    .HasColumnName("s_class")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SConnect)
                    .HasColumnName("s_connect")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SCountry)
                    .HasColumnName("s_country")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SDepTime)
                    .HasColumnName("s_dep_time")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SDing)
                    .HasColumnName("s_ding")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SDiscount)
                    .HasColumnName("s_discount")
                    .HasColumnType("char(4)");

                entity.Property(e => e.SEmail)
                    .HasColumnName("s_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SFox)
                    .HasColumnName("s_fox")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SGroupNo)
                    .HasColumnName("s_group_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SIdCard)
                    .HasColumnName("s_id_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SInGuest)
                    .HasColumnName("s_in_guest")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SIsGroup)
                    .HasColumnName("s_is_group")
                    .HasColumnType("char(12)");

                entity.Property(e => e.SKeyno)
                    .HasColumnName("s_keyno")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SLevel)
                    .HasColumnName("s_level")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SOutClass)
                    .HasColumnName("s_out_class")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SOutEmp)
                    .HasColumnName("s_out_emp")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SPaymth)
                    .HasColumnName("s_paymth")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SResvnum)
                    .HasColumnName("s_resvnum")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SRoomNo)
                    .HasColumnName("s_room_no")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SRoomType)
                    .HasColumnName("s_room_type")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SSale)
                    .HasColumnName("s_sale")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaAcct)
                    .HasColumnName("s_sauna_acct")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaKeyno)
                    .HasColumnName("s_sauna_keyno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaacct)
                    .HasColumnName("s_saunaacct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SSaunaend)
                    .HasColumnName("s_saunaend")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SSecret)
                    .HasColumnName("s_secret")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSetWorkNo)
                    .HasColumnName("s_set_work_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.STax)
                    .HasColumnName("s_tax")
                    .HasColumnType("char(1)");

                entity.Property(e => e.STaxEmp)
                    .HasColumnName("s_tax_emp")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.STele)
                    .HasColumnName("s_tele")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STogether)
                    .HasColumnName("s_together")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.STurnAccnt)
                    .HasColumnName("s_turn_accnt")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SUnionSauna)
                    .HasColumnName("s_union_sauna")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SVisaCard)
                    .HasColumnName("s_visa_card")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SVisaType)
                    .HasColumnName("s_visa_type")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SYudinNo)
                    .HasColumnName("s_yudin_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Saler)
                    .HasColumnName("saler")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportDate)
                    .HasColumnName("seaport_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportIn)
                    .HasColumnName("seaport_in")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecLevel)
                    .HasColumnName("sec_level")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SsLateSign)
                    .HasColumnName("ss_late_sign")
                    .HasColumnType("char(1)");

                entity.Property(e => e.StartDep)
                    .HasColumnName("start_dep")
                    .HasColumnType("char(10)");

                entity.Property(e => e.StatiGtype)
                    .HasColumnName("stati_gtype")
                    .HasColumnType("char(2)");

                entity.Property(e => e.TbRequest)
                    .HasColumnName("tb_request")
                    .HasColumnType("char(40)");

                entity.Property(e => e.VcAddress)
                    .HasColumnName("vc_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcCompany)
                    .HasColumnName("vc_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcName)
                    .HasColumnName("vc_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VcRemark)
                    .HasColumnName("vc_remark")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VcTel)
                    .HasColumnName("vc_tel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName1)
                    .HasColumnName("ve_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName2)
                    .HasColumnName("ve_name2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VipCard)
                    .HasColumnName("vip_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VipCode)
                    .HasColumnName("vip_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VipNo)
                    .HasColumnName("vip_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Vipcardid)
                    .HasColumnName("vipcardid")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Viplevel)
                    .HasColumnName("viplevel")
                    .HasColumnType("char(2)");

                entity.Property(e => e.VisaValidity)
                    .HasColumnName("visa_validity")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Wq)
                    .HasColumnName("wq")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.HasKey(e => e.SWorkNo);

                entity.ToTable("operator");

                entity.Property(e => e.SWorkNo)
                    .HasColumnName("s_work_no")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CLevel)
                    .HasColumnName("c_level")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CSex)
                    .HasColumnName("c_sex")
                    .HasColumnType("char(2)");

                entity.Property(e => e.CloseFlag)
                    .HasColumnName("close_flag")
                    .HasColumnType("char(1)");

                entity.Property(e => e.DSetDate)
                    .HasColumnName("d_set_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Iflogin)
                    .IsRequired()
                    .HasColumnName("iflogin")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Leader)
                    .HasColumnName("leader")
                    .HasColumnType("char(4)");

                entity.Property(e => e.MinimumDiscountRate).HasColumnType("char(10)");

                entity.Property(e => e.Modifier)
                    .HasColumnName("modifier")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Printpwd)
                    .HasColumnName("printpwd")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SGade)
                    .HasColumnName("s_gade")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SLearder)
                    .HasColumnName("s_learder")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SPassword)
                    .HasColumnName("s_password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SSetWorkNo)
                    .HasColumnName("s_set_work_no")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.SalesFlag)
                    .IsRequired()
                    .HasColumnName("sales_flag")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TReport)
                    .HasColumnName("t_report")
                    .HasColumnType("char(10)");

                entity.Property(e => e.VcAddress)
                    .HasColumnName("vc_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcName)
                    .HasColumnName("vc_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VcPopWindow)
                    .HasColumnName("vc_pop_window")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VcTel)
                    .HasColumnName("vc_tel")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parametre>(entity =>
            {
                entity.HasKey(e => e.DDate);

                entity.ToTable("parametre");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccntComp)
                    .HasColumnName("accnt_comp")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntGrop)
                    .IsRequired()
                    .HasColumnName("accnt_grop")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntHis)
                    .HasColumnName("accnt_his")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntMemb)
                    .IsRequired()
                    .HasColumnName("accnt_memb")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntRegi)
                    .IsRequired()
                    .HasColumnName("accnt_regi")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntResv)
                    .IsRequired()
                    .HasColumnName("accnt_resv")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntSign)
                    .IsRequired()
                    .HasColumnName("accnt_sign")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntStrt)
                    .IsRequired()
                    .HasColumnName("accnt_strt")
                    .HasColumnType("char(10)");

                entity.Property(e => e.AccntVip)
                    .HasColumnName("accnt_vip")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Adelpara)
                    .HasColumnName("adelpara")
                    .HasColumnType("char(44)");

                entity.Property(e => e.DJijin)
                    .HasColumnName("d_jijin")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Dbdate)
                    .HasColumnName("dbdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DhOnoff)
                    .IsRequired()
                    .HasColumnName("dh_onoff")
                    .HasColumnType("char(1)");

                entity.Property(e => e.GrapeSize)
                    .HasColumnName("grape_size")
                    .HasColumnType("char(5)");

                entity.Property(e => e.GstNo)
                    .HasColumnName("gst_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.HotelNameEn)
                    .HasColumnName("hotel_name_en")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsMultiple)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.License)
                    .HasColumnName("license")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Night)
                    .IsRequired()
                    .HasColumnName("night")
                    .HasColumnType("char(1)");

                entity.Property(e => e.PayNo)
                    .HasColumnName("pay_no")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RailRate)
                    .IsRequired()
                    .HasColumnName("rail_rate")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Rent)
                    .IsRequired()
                    .HasColumnName("rent")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SBranchNo)
                    .HasColumnName("s_branch_no")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SCardNo)
                    .HasColumnName("s_card_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SDepartment)
                    .HasColumnName("s_department")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SGroupNo)
                    .HasColumnName("s_group_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SLockid)
                    .HasColumnName("s_lockid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SModify)
                    .HasColumnName("s_modify")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SPrintRecord)
                    .HasColumnName("s_print_record")
                    .HasColumnType("char(12)");

                entity.Property(e => e.SSeekNo)
                    .HasColumnName("s_seek_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.STransFlag)
                    .HasColumnName("s_trans_flag")
                    .HasColumnType("char(10)");

                entity.Property(e => e.ServRate)
                    .IsRequired()
                    .HasColumnName("serv_rate")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SetAddcost)
                    .HasColumnName("set_addcost")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Stockno)
                    .HasColumnName("stockno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Taojia)
                    .HasColumnName("taojia")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TelePara)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasColumnType("char(20)");

                entity.Property(e => e.VipcardSet)
                    .HasColumnName("vipcard_set")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Yajinghao)
                    .HasColumnName("yajinghao")
                    .HasColumnType("char(9)");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.SAccountNo);

                entity.ToTable("register");

                entity.Property(e => e.SAccountNo)
                    .HasColumnName("s_account_no")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdCompany)
                    .HasColumnName("ad_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Authorize)
                    .HasColumnName("authorize")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Bar)
                    .HasColumnName("bar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Breakfast)
                    .HasColumnName("breakfast")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CIsTurn)
                    .HasColumnName("c_is_turn")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CServe)
                    .HasColumnName("c_serve")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CSex)
                    .HasColumnName("c_sex")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CompAcct)
                    .HasColumnName("comp_acct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.CtDept)
                    .HasColumnName("CT_Dept")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveDate)
                    .HasColumnName("d_arrive_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveWorkdate)
                    .HasColumnName("d_arrive_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DBirthday)
                    .HasColumnName("d_birthday")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DCheckoutDate)
                    .HasColumnName("d_checkout_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDaishou)
                    .HasColumnName("d_daishou")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DDepartDate)
                    .HasColumnName("d_depart_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DDepartWorkdate)
                    .HasColumnName("d_depart_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DHotelDate)
                    .HasColumnName("d_hotel_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DOutDate)
                    .HasColumnName("d_out_date")
                    .HasColumnType("char(10)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DSaunaTotcharge).HasColumnName("d_sauna_totcharge");

                entity.Property(e => e.DSetDate)
                    .HasColumnName("d_set_date")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Daysin).HasColumnName("daysin");

                entity.Property(e => e.DelayCode)
                    .HasColumnName("delay_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.DelayEmp)
                    .HasColumnName("delay_emp")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DiscPerson)
                    .HasColumnName("disc_person")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Event)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinDate)
                    .HasColumnName("fin_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.GtosMark)
                    .HasColumnName("gtos_mark")
                    .HasColumnType("char(30)");

                entity.Property(e => e.GtosMss)
                    .HasColumnName("gtos_mss")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Gtype)
                    .HasColumnName("gtype")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GtypeCode)
                    .HasColumnName("gtype_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.GuestNote)
                    .HasColumnName("guest_note")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LateDate)
                    .HasColumnName("late_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.LateDays).HasColumnName("late_days");

                entity.Property(e => e.LateTime)
                    .HasColumnName("late_time")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Marks)
                    .HasColumnName("marks")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NBalance)
                    .HasColumnName("n_balance")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NCharge)
                    .HasColumnName("n_charge")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NCount).HasColumnName("n_count");

                entity.Property(e => e.NFactRate)
                    .HasColumnName("n_fact_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.NGuest).HasColumnName("n_guest");

                entity.Property(e => e.NPay)
                    .HasColumnName("n_pay")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NSaunaChg).HasColumnName("n_sauna_chg");

                entity.Property(e => e.NServe)
                    .HasColumnName("n_serve")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NStandRate)
                    .HasColumnName("n_stand_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NTax).HasColumnName("n_tax");

                entity.Property(e => e.OSize)
                    .HasColumnName("o_size")
                    .HasColumnType("char(2)");

                entity.Property(e => e.OrgDate)
                    .HasColumnName("org_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.OriType)
                    .HasColumnName("ori_type")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Pl)
                    .HasColumnName("pl")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCode)
                    .HasColumnName("price_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.RateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RecordCode)
                    .HasColumnName("record_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Resvnid)
                    .HasColumnName("resvnid")
                    .HasColumnType("numeric(12, 0)");

                entity.Property(e => e.SCardType)
                    .HasColumnName("s_card_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SCheckOut)
                    .HasColumnName("s_check_out")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SCheckout)
                    .HasColumnName("s_checkout")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SClass)
                    .HasColumnName("s_class")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.SConnect)
                    .HasColumnName("s_connect")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SCountry)
                    .HasColumnName("s_country")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SDepTime)
                    .HasColumnName("s_dep_time")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SDing)
                    .HasColumnName("s_ding")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SDiscount)
                    .HasColumnName("s_discount")
                    .HasColumnType("char(4)");

                entity.Property(e => e.SEmail)
                    .HasColumnName("s_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SFox)
                    .HasColumnName("s_fox")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SGroupNo)
                    .HasColumnName("s_group_no")
                    .HasColumnType("char(10)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SIdCard)
                    .HasColumnName("s_id_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SInGuest)
                    .HasColumnName("s_in_guest")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SIsGroup)
                    .HasColumnName("s_is_group")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SKeyno)
                    .HasColumnName("s_keyno")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SLevel)
                    .HasColumnName("s_level")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SOutClass)
                    .HasColumnName("s_out_class")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SOutEmp)
                    .HasColumnName("s_out_emp")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SPaymth)
                    .HasColumnName("s_paymth")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SResvnum)
                    .HasColumnName("s_resvnum")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SRoomNo)
                    .IsRequired()
                    .HasColumnName("s_room_no")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SRoomType)
                    .IsRequired()
                    .HasColumnName("s_room_type")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SSale)
                    .HasColumnName("s_sale")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaAcct)
                    .HasColumnName("s_sauna_acct")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaKeyno)
                    .HasColumnName("s_sauna_keyno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaacct)
                    .HasColumnName("s_saunaacct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SSaunaend)
                    .HasColumnName("s_saunaend")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SSecret)
                    .HasColumnName("s_secret")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSetWorkNo)
                    .HasColumnName("s_set_work_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.STax)
                    .HasColumnName("s_tax")
                    .HasColumnType("char(1)");

                entity.Property(e => e.STaxEmp)
                    .HasColumnName("s_tax_emp")
                    .HasColumnType("char(6)");

                entity.Property(e => e.STele)
                    .HasColumnName("s_tele")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STogether)
                    .HasColumnName("s_together")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.STurnAccnt)
                    .HasColumnName("s_turn_accnt")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SUnionSauna)
                    .HasColumnName("s_union_sauna")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SVisaCard)
                    .HasColumnName("s_visa_card")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SVisaType)
                    .HasColumnName("s_visa_type")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SYudinNo)
                    .HasColumnName("s_yudin_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Saler)
                    .HasColumnName("saler")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportDate)
                    .HasColumnName("seaport_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportIn)
                    .HasColumnName("seaport_in")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecLevel)
                    .HasColumnName("sec_level")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SsLateSign)
                    .HasColumnName("ss_late_sign")
                    .HasColumnType("char(1)");

                entity.Property(e => e.StartDep)
                    .HasColumnName("start_dep")
                    .HasColumnType("char(10)");

                entity.Property(e => e.StatiGtype)
                    .HasColumnName("stati_gtype")
                    .HasColumnType("char(2)");

                entity.Property(e => e.TbRequest)
                    .HasColumnName("tb_request")
                    .HasColumnType("char(40)");

                entity.Property(e => e.VcAddress)
                    .HasColumnName("vc_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcCompany)
                    .HasColumnName("vc_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcName)
                    .HasColumnName("vc_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VcRemark)
                    .HasColumnName("vc_remark")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VcTel)
                    .HasColumnName("vc_tel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName1)
                    .HasColumnName("ve_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName2)
                    .HasColumnName("ve_name2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VipCard)
                    .HasColumnName("vip_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VipCode)
                    .HasColumnName("vip_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VipNo)
                    .HasColumnName("vip_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Vipcardid)
                    .HasColumnName("vipcardid")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Viplevel)
                    .HasColumnName("viplevel")
                    .HasColumnType("char(2)");

                entity.Property(e => e.VisaValidity)
                    .HasColumnName("visa_validity")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Wq)
                    .HasColumnName("wq")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterNorate>(entity =>
            {
                entity.HasKey(e => e.SAccountNo);

                entity.ToTable("register_norate");

                entity.Property(e => e.SAccountNo)
                    .HasColumnName("s_account_no")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdCompany)
                    .HasColumnName("ad_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Authorize)
                    .HasColumnName("authorize")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Bar)
                    .HasColumnName("bar")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Breakfast)
                    .HasColumnName("breakfast")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CIsTurn)
                    .HasColumnName("c_is_turn")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CServe)
                    .HasColumnName("c_serve")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CSex)
                    .HasColumnName("c_sex")
                    .HasColumnType("char(1)");

                entity.Property(e => e.CompAcct)
                    .HasColumnName("comp_acct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.CtDept)
                    .HasColumnName("CT_Dept")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveDate)
                    .HasColumnName("d_arrive_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DArriveWorkdate)
                    .HasColumnName("d_arrive_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DBirthday)
                    .HasColumnName("d_birthday")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DCheckoutDate)
                    .HasColumnName("d_checkout_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DDaishou)
                    .HasColumnName("d_daishou")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.DDepartDate)
                    .HasColumnName("d_depart_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DDepartWorkdate)
                    .HasColumnName("d_depart_workdate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DHotelDate)
                    .HasColumnName("d_hotel_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DOutDate)
                    .HasColumnName("d_out_date")
                    .HasColumnType("char(10)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DSaunaTotcharge).HasColumnName("d_sauna_totcharge");

                entity.Property(e => e.DSetDate)
                    .HasColumnName("d_set_date")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Daysin).HasColumnName("daysin");

                entity.Property(e => e.DelayCode)
                    .HasColumnName("delay_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.DelayEmp)
                    .HasColumnName("delay_emp")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DiscPerson)
                    .HasColumnName("disc_person")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Event)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinDate)
                    .HasColumnName("fin_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.GtosMark)
                    .HasColumnName("gtos_mark")
                    .HasColumnType("char(30)");

                entity.Property(e => e.GtosMss)
                    .HasColumnName("gtos_mss")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Gtype)
                    .HasColumnName("gtype")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GtypeCode)
                    .HasColumnName("gtype_code")
                    .HasColumnType("char(2)");

                entity.Property(e => e.GuestNote)
                    .HasColumnName("guest_note")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LateDate)
                    .HasColumnName("late_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.LateDays).HasColumnName("late_days");

                entity.Property(e => e.LateTime)
                    .HasColumnName("late_time")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Marks)
                    .HasColumnName("marks")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NBalance)
                    .HasColumnName("n_balance")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NCharge)
                    .HasColumnName("n_charge")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NCount).HasColumnName("n_count");

                entity.Property(e => e.NFactRate)
                    .HasColumnName("n_fact_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.NGuest).HasColumnName("n_guest");

                entity.Property(e => e.NPay)
                    .HasColumnName("n_pay")
                    .HasColumnType("numeric(12, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NSaunaChg).HasColumnName("n_sauna_chg");

                entity.Property(e => e.NServe)
                    .HasColumnName("n_serve")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NStandRate)
                    .HasColumnName("n_stand_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NTax).HasColumnName("n_tax");

                entity.Property(e => e.OSize)
                    .HasColumnName("o_size")
                    .HasColumnType("char(2)");

                entity.Property(e => e.OrgDate)
                    .HasColumnName("org_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.OriType)
                    .HasColumnName("ori_type")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Pl)
                    .HasColumnName("pl")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PriceCode)
                    .HasColumnName("price_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.RateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.RecordCode)
                    .HasColumnName("record_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Resvnid)
                    .HasColumnName("resvnid")
                    .HasColumnType("numeric(12, 0)");

                entity.Property(e => e.SCardType)
                    .HasColumnName("s_card_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SCheckOut)
                    .HasColumnName("s_check_out")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SCheckout)
                    .HasColumnName("s_checkout")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SClass)
                    .HasColumnName("s_class")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.SConnect)
                    .HasColumnName("s_connect")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SCountry)
                    .HasColumnName("s_country")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SDepTime)
                    .HasColumnName("s_dep_time")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SDing)
                    .HasColumnName("s_ding")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SDiscount)
                    .HasColumnName("s_discount")
                    .HasColumnType("char(4)");

                entity.Property(e => e.SEmail)
                    .HasColumnName("s_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SFox)
                    .HasColumnName("s_fox")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SGroupNo)
                    .HasColumnName("s_group_no")
                    .HasColumnType("char(10)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SIdCard)
                    .HasColumnName("s_id_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SInGuest)
                    .HasColumnName("s_in_guest")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SIsGroup)
                    .HasColumnName("s_is_group")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SKeyno)
                    .HasColumnName("s_keyno")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SLevel)
                    .HasColumnName("s_level")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SOutClass)
                    .HasColumnName("s_out_class")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SOutEmp)
                    .HasColumnName("s_out_emp")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SPaymth)
                    .HasColumnName("s_paymth")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SResvnum)
                    .HasColumnName("s_resvnum")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SRoomNo)
                    .HasColumnName("s_room_no")
                    .HasColumnType("char(5)");

                entity.Property(e => e.SRoomType)
                    .HasColumnName("s_room_type")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SSale)
                    .HasColumnName("s_sale")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaAcct)
                    .HasColumnName("s_sauna_acct")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaKeyno)
                    .HasColumnName("s_sauna_keyno")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SSaunaacct)
                    .HasColumnName("s_saunaacct")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SSaunaend)
                    .HasColumnName("s_saunaend")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SSecret)
                    .HasColumnName("s_secret")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.SSetWorkNo)
                    .HasColumnName("s_set_work_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.STax)
                    .HasColumnName("s_tax")
                    .HasColumnType("char(1)");

                entity.Property(e => e.STaxEmp)
                    .HasColumnName("s_tax_emp")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.STele)
                    .HasColumnName("s_tele")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.STogether)
                    .HasColumnName("s_together")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.STurnAccnt)
                    .HasColumnName("s_turn_accnt")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SUnionSauna)
                    .HasColumnName("s_union_sauna")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SVisaCard)
                    .HasColumnName("s_visa_card")
                    .HasColumnType("char(20)");

                entity.Property(e => e.SVisaType)
                    .HasColumnName("s_visa_type")
                    .HasColumnType("char(10)");

                entity.Property(e => e.SYudinNo)
                    .HasColumnName("s_yudin_no")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Saler)
                    .HasColumnName("saler")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportDate)
                    .HasColumnName("seaport_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeaportIn)
                    .HasColumnName("seaport_in")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecLevel)
                    .HasColumnName("sec_level")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SsLateSign)
                    .HasColumnName("ss_late_sign")
                    .HasColumnType("char(1)");

                entity.Property(e => e.StartDep)
                    .HasColumnName("start_dep")
                    .HasColumnType("char(10)");

                entity.Property(e => e.StatiGtype)
                    .HasColumnName("stati_gtype")
                    .HasColumnType("char(2)");

                entity.Property(e => e.TbRequest)
                    .HasColumnName("tb_request")
                    .HasColumnType("char(40)");

                entity.Property(e => e.VcAddress)
                    .HasColumnName("vc_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcCompany)
                    .HasColumnName("vc_company")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VcName)
                    .HasColumnName("vc_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VcRemark)
                    .HasColumnName("vc_remark")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VcTel)
                    .HasColumnName("vc_tel")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName1)
                    .HasColumnName("ve_name1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VeName2)
                    .HasColumnName("ve_name2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VipCard)
                    .HasColumnName("vip_card")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VipCode)
                    .HasColumnName("vip_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VipNo)
                    .HasColumnName("vip_no")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Vipcardid)
                    .HasColumnName("vipcardid")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Viplevel)
                    .HasColumnName("viplevel")
                    .HasColumnType("char(2)");

                entity.Property(e => e.VisaValidity)
                    .HasColumnName("visa_validity")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Wq)
                    .HasColumnName("wq")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomState>(entity =>
            {
                entity.HasKey(e => e.SRoomNo);

                entity.ToTable("room_state");

                entity.Property(e => e.SRoomNo)
                    .HasColumnName("s_room_no")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BackBmp)
                    .HasColumnName("back_bmp")
                    .HasColumnType("char(12)");

                entity.Property(e => e.CtDept)
                    .HasColumnName("ct_dept")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DLockdate)
                    .HasColumnName("d_lockdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DSetDate)
                    .IsRequired()
                    .HasColumnName("d_set_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FinalOverdate)
                    .HasColumnName("final_overdate")
                    .HasColumnType("char(20)");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasColumnType("char(1)");

                entity.Property(e => e.GuestNum).HasColumnName("guest_num");

                entity.Property(e => e.HouseUse)
                    .HasColumnName("house_use")
                    .HasColumnType("char(6)");

                entity.Property(e => e.IsBuild)
                    .HasColumnName("is_build")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsGroup)
                    .HasColumnName("is_group")
                    .HasColumnType("char(2)");

                entity.Property(e => e.IsUsed)
                    .HasColumnName("is_used")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveBmp)
                    .HasColumnName("leave_bmp")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Lock)
                    .HasColumnName("lock")
                    .HasColumnType("char(1)");

                entity.Property(e => e.LockBmp)
                    .HasColumnName("lock_bmp")
                    .HasColumnType("char(8)");

                entity.Property(e => e.LockState)
                    .HasColumnName("lock_state")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Lockno)
                    .HasColumnName("lockno")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MessageBmp)
                    .HasColumnName("message_bmp")
                    .HasColumnType("char(80)");

                entity.Property(e => e.NFactPerson)
                    .HasColumnName("n_fact_person")
                    .HasColumnType("char(2)");

                entity.Property(e => e.NShouldPerson).HasColumnName("n_should_person");

                entity.Property(e => e.NoUseSize)
                    .HasColumnName("no_use_size")
                    .HasColumnType("char(2)");

                entity.Property(e => e.OcOd)
                    .HasColumnName("oc_od")
                    .HasColumnType("char(1)");

                entity.Property(e => e.OtherBmp)
                    .HasColumnName("other_bmp")
                    .HasColumnType("char(12)");

                entity.Property(e => e.RoomDcr)
                    .HasColumnName("room_dcr")
                    .HasColumnType("char(4)");

                entity.Property(e => e.SBuilding)
                    .HasColumnName("s_building")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SDayState)
                    .HasColumnName("s_day_state")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SFloor)
                    .HasColumnName("s_floor")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SHotelOpen)
                    .HasColumnName("s_hotel_open")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SHotelUse)
                    .HasColumnName("s_hotel_use")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SLockid)
                    .HasColumnName("s_lockid")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SMainroom)
                    .HasColumnName("s_mainroom")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SNewState)
                    .HasColumnName("s_new_state")
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SRoomExp)
                    .HasColumnName("s_room_exp")
                    .HasColumnType("char(200)");

                entity.Property(e => e.SRoomState)
                    .IsRequired()
                    .HasColumnName("s_room_state")
                    .HasColumnType("char(1)");

                entity.Property(e => e.SRoomType)
                    .IsRequired()
                    .HasColumnName("s_room_type")
                    .HasColumnType("char(3)");

                entity.Property(e => e.SSetWorkNo)
                    .IsRequired()
                    .HasColumnName("s_set_work_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.SecState)
                    .HasColumnName("sec_state")
                    .HasColumnType("char(4)");

                entity.Property(e => e.ViewSign)
                    .HasColumnName("view_sign")
                    .HasColumnType("char(1)");

                entity.Property(e => e.VipBmp)
                    .HasColumnName("vip_bmp")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Vod)
                    .HasColumnName("vod")
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.HasKey(e => e.SRoomType);

                entity.ToTable("room_type");

                entity.Property(e => e.SRoomType)
                    .HasColumnName("s_room_type")
                    .HasColumnType("char(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DSetDate)
                    .IsRequired()
                    .HasColumnName("d_set_date")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraRoom)
                    .HasColumnName("extra_room")
                    .HasColumnType("numeric(3, 0)");

                entity.Property(e => e.NAmount)
                    .IsRequired()
                    .HasColumnName("n_amount")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.NHourPrice)
                    .HasColumnName("n_hour_price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.NInRate)
                    .HasColumnName("n_in_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.NRoomRate)
                    .IsRequired()
                    .HasColumnName("n_room_rate")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.SBreakfast)
                    .HasColumnName("s_breakfast")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SRent)
                    .HasColumnName("s_rent")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SSetWorkNo)
                    .IsRequired()
                    .HasColumnName("s_set_work_no")
                    .HasColumnType("char(6)");

                entity.Property(e => e.SShow)
                    .HasColumnName("s_show")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VsDescribe)
                    .IsRequired()
                    .HasColumnName("vs_describe")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TRoomSign>(entity =>
            {
                entity.HasKey(e => e.TIc);

                entity.ToTable("t_room_sign");

                entity.Property(e => e.TIc)
                    .HasColumnName("t_ic")
                    .HasColumnType("char(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.TDate)
                    .HasColumnName("t_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TDec)
                    .HasColumnName("t_dec")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TEmp)
                    .HasColumnName("t_emp")
                    .HasColumnType("char(20)");

                entity.Property(e => e.TLong).HasColumnName("t_long");

                entity.Property(e => e.TSetDate)
                    .HasColumnName("t_set_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TSignName)
                    .HasColumnName("t_sign_name")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TStr)
                    .HasColumnName("t_str")
                    .HasColumnType("char(20)");

                entity.Property(e => e.TType)
                    .HasColumnName("t_type")
                    .HasColumnType("char(10)");
            });
        }
    }
}
