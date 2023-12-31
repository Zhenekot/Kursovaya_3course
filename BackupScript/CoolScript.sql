PGDMP     5                     {            KursovayaCreatourFour    14.5    14.5 J    I           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            J           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            K           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            L           1262    42207    KursovayaCreatourFour    DATABASE     t   CREATE DATABASE "KursovayaCreatourFour" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
 '   DROP DATABASE "KursovayaCreatourFour";
                postgres    false            �            1259    42225    client    TABLE     u  CREATE TABLE public.client (
    id_client integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    patronymic character varying(30),
    phone_number character varying(11) NOT NULL,
    email character varying(50) NOT NULL,
    date_of_birth date NOT NULL,
    passport_series_and_number character varying(10) NOT NULL
);
    DROP TABLE public.client;
       public         heap    postgres    false            �            1259    42224    client_id_client_seq    SEQUENCE     �   CREATE SEQUENCE public.client_id_client_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.client_id_client_seq;
       public          postgres    false    214            M           0    0    client_id_client_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.client_id_client_seq OWNED BY public.client.id_client;
          public          postgres    false    213            �            1259    42271    employee    TABLE     �  CREATE TABLE public.employee (
    id_employee integer NOT NULL,
    name character varying(20) NOT NULL,
    surname character varying(20) NOT NULL,
    patronymic character varying(30),
    phone_number character varying(11) NOT NULL,
    date_of_birth date NOT NULL,
    "position" integer NOT NULL,
    password character varying(30) NOT NULL,
    status character varying(15) NOT NULL,
    login character varying(30) NOT NULL
);
    DROP TABLE public.employee;
       public         heap    postgres    false            �            1259    42270    employee_id_employee_seq    SEQUENCE     �   CREATE SEQUENCE public.employee_id_employee_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.employee_id_employee_seq;
       public          postgres    false    222            N           0    0    employee_id_employee_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.employee_id_employee_seq OWNED BY public.employee.id_employee;
          public          postgres    false    221            �            1259    42238    hotel    TABLE       CREATE TABLE public.hotel (
    id_hotel integer NOT NULL,
    title character varying(20) NOT NULL,
    hotel_class integer NOT NULL,
    city character varying(50) NOT NULL,
    address character varying(20) NOT NULL,
    phone_number character varying(11) NOT NULL
);
    DROP TABLE public.hotel;
       public         heap    postgres    false            �            1259    42237    hotel_id_hotel_seq    SEQUENCE     �   CREATE SEQUENCE public.hotel_id_hotel_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.hotel_id_hotel_seq;
       public          postgres    false    216            O           0    0    hotel_id_hotel_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.hotel_id_hotel_seq OWNED BY public.hotel.id_hotel;
          public          postgres    false    215            �            1259    42218    position    TABLE     �   CREATE TABLE public."position" (
    id_position integer NOT NULL,
    title character varying(20) NOT NULL,
    salary numeric(10,2) NOT NULL
);
    DROP TABLE public."position";
       public         heap    postgres    false            �            1259    42217    position_id_position_seq    SEQUENCE     �   CREATE SEQUENCE public.position_id_position_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.position_id_position_seq;
       public          postgres    false    212            P           0    0    position_id_position_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE public.position_id_position_seq OWNED BY public."position".id_position;
          public          postgres    false    211            �            1259    42285    sale    TABLE     C  CREATE TABLE public.sale (
    id_sale integer NOT NULL,
    full_cost numeric(10,2) NOT NULL,
    date_of_sale timestamp without time zone NOT NULL,
    rejection character varying(15) NOT NULL,
    client integer NOT NULL,
    hotel integer NOT NULL,
    transportation integer NOT NULL,
    employee integer NOT NULL
);
    DROP TABLE public.sale;
       public         heap    postgres    false            �            1259    42284    sale_id_sale_seq    SEQUENCE     �   CREATE SEQUENCE public.sale_id_sale_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.sale_id_sale_seq;
       public          postgres    false    224            Q           0    0    sale_id_sale_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.sale_id_sale_seq OWNED BY public.sale.id_sale;
          public          postgres    false    223            �            1259    42247    tour    TABLE     �   CREATE TABLE public.tour (
    id_tour integer NOT NULL,
    title character varying(80) NOT NULL,
    city character varying(50) NOT NULL,
    excursion character varying(500) NOT NULL
);
    DROP TABLE public.tour;
       public         heap    postgres    false            �            1259    42246    tour_id_tour_seq    SEQUENCE     �   CREATE SEQUENCE public.tour_id_tour_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.tour_id_tour_seq;
       public          postgres    false    218            R           0    0    tour_id_tour_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.tour_id_tour_seq OWNED BY public.tour.id_tour;
          public          postgres    false    217            �            1259    42209 	   transport    TABLE     �   CREATE TABLE public.transport (
    id_transport integer NOT NULL,
    title character varying(20) NOT NULL,
    number character varying(5) NOT NULL,
    count_seat numeric(2,0) NOT NULL
);
    DROP TABLE public.transport;
       public         heap    postgres    false            �            1259    42208    transport_id_transport_seq    SEQUENCE     �   CREATE SEQUENCE public.transport_id_transport_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.transport_id_transport_seq;
       public          postgres    false    210            S           0    0    transport_id_transport_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.transport_id_transport_seq OWNED BY public.transport.id_transport;
          public          postgres    false    209            �            1259    42254    transportation    TABLE     m  CREATE TABLE public.transportation (
    id_transportation integer NOT NULL,
    title character varying(80) NOT NULL,
    start_date timestamp without time zone NOT NULL,
    end_date timestamp without time zone NOT NULL,
    tour integer NOT NULL,
    transport integer NOT NULL,
    type_of_food character varying(2) NOT NULL,
    cost numeric(10,2) NOT NULL
);
 "   DROP TABLE public.transportation;
       public         heap    postgres    false            �            1259    42253 $   transportation_id_transportation_seq    SEQUENCE     �   CREATE SEQUENCE public.transportation_id_transportation_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ;   DROP SEQUENCE public.transportation_id_transportation_seq;
       public          postgres    false    220            T           0    0 $   transportation_id_transportation_seq    SEQUENCE OWNED BY     m   ALTER SEQUENCE public.transportation_id_transportation_seq OWNED BY public.transportation.id_transportation;
          public          postgres    false    219            �           2604    42228    client id_client    DEFAULT     t   ALTER TABLE ONLY public.client ALTER COLUMN id_client SET DEFAULT nextval('public.client_id_client_seq'::regclass);
 ?   ALTER TABLE public.client ALTER COLUMN id_client DROP DEFAULT;
       public          postgres    false    213    214    214            �           2604    42274    employee id_employee    DEFAULT     |   ALTER TABLE ONLY public.employee ALTER COLUMN id_employee SET DEFAULT nextval('public.employee_id_employee_seq'::regclass);
 C   ALTER TABLE public.employee ALTER COLUMN id_employee DROP DEFAULT;
       public          postgres    false    222    221    222            �           2604    42241    hotel id_hotel    DEFAULT     p   ALTER TABLE ONLY public.hotel ALTER COLUMN id_hotel SET DEFAULT nextval('public.hotel_id_hotel_seq'::regclass);
 =   ALTER TABLE public.hotel ALTER COLUMN id_hotel DROP DEFAULT;
       public          postgres    false    216    215    216            �           2604    42221    position id_position    DEFAULT     ~   ALTER TABLE ONLY public."position" ALTER COLUMN id_position SET DEFAULT nextval('public.position_id_position_seq'::regclass);
 E   ALTER TABLE public."position" ALTER COLUMN id_position DROP DEFAULT;
       public          postgres    false    212    211    212            �           2604    42288    sale id_sale    DEFAULT     l   ALTER TABLE ONLY public.sale ALTER COLUMN id_sale SET DEFAULT nextval('public.sale_id_sale_seq'::regclass);
 ;   ALTER TABLE public.sale ALTER COLUMN id_sale DROP DEFAULT;
       public          postgres    false    223    224    224            �           2604    42250    tour id_tour    DEFAULT     l   ALTER TABLE ONLY public.tour ALTER COLUMN id_tour SET DEFAULT nextval('public.tour_id_tour_seq'::regclass);
 ;   ALTER TABLE public.tour ALTER COLUMN id_tour DROP DEFAULT;
       public          postgres    false    217    218    218                       2604    42212    transport id_transport    DEFAULT     �   ALTER TABLE ONLY public.transport ALTER COLUMN id_transport SET DEFAULT nextval('public.transport_id_transport_seq'::regclass);
 E   ALTER TABLE public.transport ALTER COLUMN id_transport DROP DEFAULT;
       public          postgres    false    209    210    210            �           2604    42257     transportation id_transportation    DEFAULT     �   ALTER TABLE ONLY public.transportation ALTER COLUMN id_transportation SET DEFAULT nextval('public.transportation_id_transportation_seq'::regclass);
 O   ALTER TABLE public.transportation ALTER COLUMN id_transportation DROP DEFAULT;
       public          postgres    false    219    220    220            <          0    42225    client 
   TABLE DATA           �   COPY public.client (id_client, name, surname, patronymic, phone_number, email, date_of_birth, passport_series_and_number) FROM stdin;
    public          postgres    false    214   �Z       D          0    42271    employee 
   TABLE DATA           �   COPY public.employee (id_employee, name, surname, patronymic, phone_number, date_of_birth, "position", password, status, login) FROM stdin;
    public          postgres    false    222   �[       >          0    42238    hotel 
   TABLE DATA           Z   COPY public.hotel (id_hotel, title, hotel_class, city, address, phone_number) FROM stdin;
    public          postgres    false    216   M]       :          0    42218    position 
   TABLE DATA           @   COPY public."position" (id_position, title, salary) FROM stdin;
    public          postgres    false    212   V^       F          0    42285    sale 
   TABLE DATA           t   COPY public.sale (id_sale, full_cost, date_of_sale, rejection, client, hotel, transportation, employee) FROM stdin;
    public          postgres    false    224   �^       @          0    42247    tour 
   TABLE DATA           ?   COPY public.tour (id_tour, title, city, excursion) FROM stdin;
    public          postgres    false    218   R_       8          0    42209 	   transport 
   TABLE DATA           L   COPY public.transport (id_transport, title, number, count_seat) FROM stdin;
    public          postgres    false    210   d       B          0    42254    transportation 
   TABLE DATA           }   COPY public.transportation (id_transportation, title, start_date, end_date, tour, transport, type_of_food, cost) FROM stdin;
    public          postgres    false    220   �d       U           0    0    client_id_client_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.client_id_client_seq', 8, true);
          public          postgres    false    213            V           0    0    employee_id_employee_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.employee_id_employee_seq', 15, true);
          public          postgres    false    221            W           0    0    hotel_id_hotel_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.hotel_id_hotel_seq', 7, true);
          public          postgres    false    215            X           0    0    position_id_position_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.position_id_position_seq', 3, true);
          public          postgres    false    211            Y           0    0    sale_id_sale_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.sale_id_sale_seq', 19, true);
          public          postgres    false    223            Z           0    0    tour_id_tour_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.tour_id_tour_seq', 5, true);
          public          postgres    false    217            [           0    0    transport_id_transport_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.transport_id_transport_seq', 8, true);
          public          postgres    false    209            \           0    0 $   transportation_id_transportation_seq    SEQUENCE SET     R   SELECT pg_catalog.setval('public.transportation_id_transportation_seq', 9, true);
          public          postgres    false    219            �           2606    42234    client client_email_key 
   CONSTRAINT     S   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_email_key UNIQUE (email);
 A   ALTER TABLE ONLY public.client DROP CONSTRAINT client_email_key;
       public            postgres    false    214            �           2606    42236 ,   client client_passport_series_and_number_key 
   CONSTRAINT     }   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_passport_series_and_number_key UNIQUE (passport_series_and_number);
 V   ALTER TABLE ONLY public.client DROP CONSTRAINT client_passport_series_and_number_key;
       public            postgres    false    214            �           2606    42232    client client_phone_number_key 
   CONSTRAINT     a   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_phone_number_key UNIQUE (phone_number);
 H   ALTER TABLE ONLY public.client DROP CONSTRAINT client_phone_number_key;
       public            postgres    false    214            �           2606    42230    client client_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (id_client);
 <   ALTER TABLE ONLY public.client DROP CONSTRAINT client_pkey;
       public            postgres    false    214            �           2606    42278 "   employee employee_phone_number_key 
   CONSTRAINT     e   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_phone_number_key UNIQUE (phone_number);
 L   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_phone_number_key;
       public            postgres    false    222            �           2606    42276    employee employee_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_pkey PRIMARY KEY (id_employee);
 @   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_pkey;
       public            postgres    false    222            �           2606    42245    hotel hotel_phone_number_key 
   CONSTRAINT     _   ALTER TABLE ONLY public.hotel
    ADD CONSTRAINT hotel_phone_number_key UNIQUE (phone_number);
 F   ALTER TABLE ONLY public.hotel DROP CONSTRAINT hotel_phone_number_key;
       public            postgres    false    216            �           2606    42243    hotel hotel_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.hotel
    ADD CONSTRAINT hotel_pkey PRIMARY KEY (id_hotel);
 :   ALTER TABLE ONLY public.hotel DROP CONSTRAINT hotel_pkey;
       public            postgres    false    216            �           2606    42320    employee loginunique 
   CONSTRAINT     P   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT loginunique UNIQUE (login);
 >   ALTER TABLE ONLY public.employee DROP CONSTRAINT loginunique;
       public            postgres    false    222            �           2606    42223    position position_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."position"
    ADD CONSTRAINT position_pkey PRIMARY KEY (id_position);
 B   ALTER TABLE ONLY public."position" DROP CONSTRAINT position_pkey;
       public            postgres    false    212            �           2606    42290    sale sale_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.sale
    ADD CONSTRAINT sale_pkey PRIMARY KEY (id_sale);
 8   ALTER TABLE ONLY public.sale DROP CONSTRAINT sale_pkey;
       public            postgres    false    224            �           2606    42252    tour tour_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.tour
    ADD CONSTRAINT tour_pkey PRIMARY KEY (id_tour);
 8   ALTER TABLE ONLY public.tour DROP CONSTRAINT tour_pkey;
       public            postgres    false    218            �           2606    42216    transport transport_number_key 
   CONSTRAINT     [   ALTER TABLE ONLY public.transport
    ADD CONSTRAINT transport_number_key UNIQUE (number);
 H   ALTER TABLE ONLY public.transport DROP CONSTRAINT transport_number_key;
       public            postgres    false    210            �           2606    42214    transport transport_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.transport
    ADD CONSTRAINT transport_pkey PRIMARY KEY (id_transport);
 B   ALTER TABLE ONLY public.transport DROP CONSTRAINT transport_pkey;
       public            postgres    false    210            �           2606    42259 "   transportation transportation_pkey 
   CONSTRAINT     o   ALTER TABLE ONLY public.transportation
    ADD CONSTRAINT transportation_pkey PRIMARY KEY (id_transportation);
 L   ALTER TABLE ONLY public.transportation DROP CONSTRAINT transportation_pkey;
       public            postgres    false    220            �           2606    42279    employee employee_position_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.employee
    ADD CONSTRAINT employee_position_fkey FOREIGN KEY ("position") REFERENCES public."position"(id_position);
 I   ALTER TABLE ONLY public.employee DROP CONSTRAINT employee_position_fkey;
       public          postgres    false    3212    212    222            �           2606    42291    sale sale_client_fkey    FK CONSTRAINT     {   ALTER TABLE ONLY public.sale
    ADD CONSTRAINT sale_client_fkey FOREIGN KEY (client) REFERENCES public.client(id_client);
 ?   ALTER TABLE ONLY public.sale DROP CONSTRAINT sale_client_fkey;
       public          postgres    false    224    214    3220            �           2606    42306    sale sale_employee_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.sale
    ADD CONSTRAINT sale_employee_fkey FOREIGN KEY (employee) REFERENCES public.employee(id_employee);
 A   ALTER TABLE ONLY public.sale DROP CONSTRAINT sale_employee_fkey;
       public          postgres    false    3232    224    222            �           2606    42296    sale sale_hotel_fkey    FK CONSTRAINT     w   ALTER TABLE ONLY public.sale
    ADD CONSTRAINT sale_hotel_fkey FOREIGN KEY (hotel) REFERENCES public.hotel(id_hotel);
 >   ALTER TABLE ONLY public.sale DROP CONSTRAINT sale_hotel_fkey;
       public          postgres    false    224    216    3224            �           2606    42301    sale sale_transportation_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.sale
    ADD CONSTRAINT sale_transportation_fkey FOREIGN KEY (transportation) REFERENCES public.transportation(id_transportation);
 G   ALTER TABLE ONLY public.sale DROP CONSTRAINT sale_transportation_fkey;
       public          postgres    false    224    220    3228            �           2606    42265 '   transportation transportation_tour_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transportation
    ADD CONSTRAINT transportation_tour_fkey FOREIGN KEY (tour) REFERENCES public.tour(id_tour);
 Q   ALTER TABLE ONLY public.transportation DROP CONSTRAINT transportation_tour_fkey;
       public          postgres    false    218    3226    220            �           2606    42260 ,   transportation transportation_transport_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.transportation
    ADD CONSTRAINT transportation_transport_fkey FOREIGN KEY (transport) REFERENCES public.transport(id_transport);
 V   ALTER TABLE ONLY public.transportation DROP CONSTRAINT transportation_transport_fkey;
       public          postgres    false    3210    220    210            <     x�U�AN�0D��wIe;���*�ĢW`�T�EJ�V�[�@�7���Ҟ��F��,@�ly����h�{�p�/�U���w�/~�_�k�[����9<���f2S:N�u4<.�y1X\��x��NIK�#�#��:�m,�'nZ��\�&K���p�����dn��$N3g�#~㭿����W��w�
����P�'�0���v�h�*���^y>?�'�ֳ\K)i�Y:g�HC����Y�0�붡oj�q�cC��l�C�e24Ӆ@X��8�	!~��      D   }  x�}��N�0�g�)��v�<�N,,��D՟�P!1�E��T�1�{hQ�Mx��7�8���
Er�c�|��&b�@�RJ���7ӧ�V�r,$��i�Յ`L!e#-�
���I��W;2b=��;�f�wj���4��M�-iA	��y�s�`�����_�0Ry~��47`�A��1T�R��q�Å��	ʢD`b��%3�fĬo��+7rp�_��޹�ʅ�h�d�د��������fv	*�A�E�������0�eMB:R1e�GBnA��'�&��#<l�KZb�f�ɧ5G~6aL,qM+�R�*G A�p��Zh��m�Z�����?ȸ�O
�l�N��osDBk4-��Z��ą_�5/��X�,�~��9�8�      >   �   x���=N1���)��v��!G�Rz��	�$�("�N��M���oĳ��4�=3��l[D�
g��Y��\�8�Ð��
>�O*l�xJ�8"TM+�YӴZk�U+اE��(&�;|c�y��/��ܥ®yOƉ����MM��2��Ϧ�Y��Ʃ�M�T.pA/LA�����X��0c���̹$$2R�/s���P�1$)^9�{.��"����>��sZ�#}]�E�]8���D)�6y��      :   S   x�-���0k{��8b�	� ��!R�(0��F�H{��p������W/h^�y���Ha%\�(,�N�t�p��Ie�-1�x )#      F   �   x�uλ1E�X��֣�eɵP��)[��ϒ�g�g��
T�@Ht!_��8z��V����x~c�����@�l�~��iR/�R4���!��]P�B��� �ܪqJ�h�����Y�:��5���?lx/��2Z�      @   �  x��Vˎ#E<����K�p�<?�8�7p��6�����	�-�"!��vO����������t����x���ʌ���ϲ�{\�:��0�b�!�7)�g���n�q��q�Q�`��xI��J�칭,��-sn��_����5>��4i��+�����+���1n��B�3>��}���yĸ�80ɀ�
>`�+���(��<��R���FA.ːɥb �6}3)���I���,V��w:��mpv�t��p���� \Jh���� ����R�L� 3˚�z\����H1��|7H�:Ɠ3"ܱ��Q�k��lB�� p\�����=E��U�ш�%���R9[8����U��!�iA�C��F�9����<�?qlJ�A��~H�&��`QUI��`��P'����� ouQe�{�ر�>���W����rs��2�>��[�Cj�٨9�0.m���1:��1�I��ꬃ�Z�	����y�86���`�·�\]]���/�Co3�,M�Y���E����:�A���%LwX��b�|��:��zcQ��t�F.,��J垫��B���-X߰B��ﯿl{���4��KV��4zL��+X�k�ZE  ���B!ڽ�ǫ����ۯe3���a�����{�`�7 ����5���l�(����N����Q��K��y�%��ΎE D�qk�����H��p��\XY����l�R�s`N۠��(),�K�e!���Y�^W��B�u�{#/��D������)兩>����Ó��!�`}'z&���s�L�����IQ��D�]x=u�����9oiy���
_fgL���#�pv�Q�wջ;�;����7�a��3E��m4CȜ�X����-0����PE*��[�g)�YL&�5�Z��VK�O"�G�)��dk%pu���
x�E�� ��D�{�k��htj�N��-OVݪ����7L���/���������x�t���ͻ�-��q���7vW}�ޝq�����}�q�4<���R,;v��u$��?:����e5IsL�|�j��6,�.tι�\�P�m�^BPN{]B�H��k����k��A�q���������	�˝���/;�������XM�Dnet�ڪ���w�}&�k�d�#s�׬s]q�{ɠw=��z��`��      8   g   x�m���0k{��NX�e���HP0 ��F8�Kh�t�4�]}�*k��ے��˕9䖱�J�b�z|��y�<?/v�ٚ[�[F���#�i@�g�c
      B     x���1N�0�g��@��w�&�F7� �i�Q'FX��R��Ph���x&F��ؐmY~~���&Xc�>,p@V6�b�\MXp�(����4\���Ѽ�lBc��"�*ge:�<j�QS��K�Nd$�U�h��"o���,���V�EJL�v#D�zx��7<l�J��V? Ur�#j�U���83��!F���:���N���"u0�� �����Iؒ�����X�O�u���¢V[-�O�g�`W�,˾ ���0     