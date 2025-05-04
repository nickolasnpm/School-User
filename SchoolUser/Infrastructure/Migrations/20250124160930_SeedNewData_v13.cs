using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolUser.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData_v13 : Migration
    {

        #region ClassSubjectTeacher
        private readonly Guid classSubjectTeacherId1 = new Guid("02ec2945-02cb-4d42-9ad3-bfd8323610eb");
        private readonly Guid classSubjectTeacherId2 = new Guid("90ecb98c-b64e-413f-9dab-386a365820b4");
        private readonly Guid classSubjectTeacherId3 = new Guid("c03d98ef-fc52-4faa-a893-0e0b4c8ca6ff");
        private readonly Guid classSubjectTeacherId4 = new Guid("c4eabd57-1892-40b9-8b2f-7dc28fe71133");
        private readonly Guid classSubjectTeacherId5 = new Guid("1e594a38-bf4e-4b53-a268-5d35e67b04d8");
        private readonly Guid classSubjectTeacherId6 = new Guid("a2fba04e-bd3f-4957-8a14-b272469741b6");
        private readonly Guid classSubjectTeacherId7 = new Guid("197fdf02-07c8-40b1-ab43-c865c8120d7d");
        private readonly Guid classSubjectTeacherId8 = new Guid("bad12310-f3e8-48a1-a2fe-99e12837e06f");
        private readonly Guid classSubjectTeacherId9 = new Guid("115c8805-3c3d-416e-8208-02b9ac9ace7f");
        private readonly Guid classSubjectTeacherId10 = new Guid("bd8b795e-7704-4276-aaee-7751fe2b8493");
        private readonly Guid classSubjectTeacherId11 = new Guid("3d44861b-7d48-458e-9fd8-42f503b2f652");
        private readonly Guid classSubjectTeacherId12 = new Guid("3cc80845-adde-4f46-b614-7285bc7b8ec9");
        private readonly Guid classSubjectTeacherId13 = new Guid("a9bee6cf-a969-4a4d-a6e9-959fc39f1b6d");
        private readonly Guid classSubjectTeacherId14 = new Guid("d89b1ffe-48f9-4572-83f7-8302d0b47080");
        private readonly Guid classSubjectTeacherId15 = new Guid("cb516a7b-a2da-458e-b374-128b84df3189");
        private readonly Guid classSubjectTeacherId16 = new Guid("f6fa124f-d90c-41f1-aa9a-94d3faddc33e");
        private readonly Guid classSubjectTeacherId17 = new Guid("9b77e0a7-17f4-4aac-8461-736533b78a99");
        private readonly Guid classSubjectTeacherId18 = new Guid("d44df945-7057-42a6-a2d3-e0f3b2df0f64");
        private readonly Guid classSubjectTeacherId19 = new Guid("78d1b9be-1ae8-4995-b54a-b50ffe738d2f");
        private readonly Guid classSubjectTeacherId20 = new Guid("2aebd936-7aba-4a0d-a539-85ebf5ba7219");
        private readonly Guid classSubjectTeacherId21 = new Guid("e66614f4-707f-4c52-838d-a7a13fd66998");
        private readonly Guid classSubjectTeacherId22 = new Guid("0347e8dc-bf52-4dfd-99a0-025ef4c72672");
        private readonly Guid classSubjectTeacherId23 = new Guid("9200eebe-520e-486f-b355-d5f354f2e488");
        private readonly Guid classSubjectTeacherId24 = new Guid("ce524cbd-6d0f-493d-9336-0bf02f4a2795");
        private readonly Guid classSubjectTeacherId25 = new Guid("34025e73-b8f1-42cd-b616-dece764205a7");
        private readonly Guid classSubjectTeacherId26 = new Guid("a0a717c5-a34c-4561-b42c-f10dfa5018ef");
        private readonly Guid classSubjectTeacherId27 = new Guid("eaef3a6a-7bbe-410d-a790-589cdd59e026");
        private readonly Guid classSubjectTeacherId28 = new Guid("3fb4d32a-dafb-4b7c-b19e-28c06119efa3");
        private readonly Guid classSubjectTeacherId29 = new Guid("c213d14f-7c33-4a42-b590-22e7193ba152");
        private readonly Guid classSubjectTeacherId30 = new Guid("fa39fb51-1323-4b81-8d6f-70cb147c8007");
        private readonly Guid classSubjectTeacherId31 = new Guid("5e12b0be-d44e-462b-93d7-787152f1c964");
        private readonly Guid classSubjectTeacherId32 = new Guid("02caedea-6864-4ef0-8cd2-8edd205da85b");
        private readonly Guid classSubjectTeacherId33 = new Guid("7c3d178a-79ff-4c24-8527-d824a0f084e0");
        private readonly Guid classSubjectTeacherId34 = new Guid("cffbb547-f44c-4a6f-9675-23e873387ea7");
        private readonly Guid classSubjectTeacherId35 = new Guid("bb35d63f-689e-416a-b95b-cf1f7f23013c");
        private readonly Guid classSubjectTeacherId36 = new Guid("13c3d1e6-19a7-4b14-ba3e-3e229253451e");
        private readonly Guid classSubjectTeacherId37 = new Guid("1efb8e2c-634b-4314-ad51-33cca1689511");
        private readonly Guid classSubjectTeacherId38 = new Guid("8bf59a5b-79dc-4832-acf5-f6c9eb94a9c5");
        private readonly Guid classSubjectTeacherId39 = new Guid("c1bc6d3e-e59a-4be5-a4ef-fd5b5a0e1dcd");
        private readonly Guid classSubjectTeacherId40 = new Guid("8c1ee445-aefd-41f5-be11-f2f3bbfdceb5");
        private readonly Guid classSubjectTeacherId41 = new Guid("962c016d-d509-4a1c-8b3b-4581b14cbb37");
        private readonly Guid classSubjectTeacherId42 = new Guid("55211c81-51f5-4493-ad71-e4d437b838d1");
        private readonly Guid classSubjectTeacherId43 = new Guid("e805a3fb-9577-4c44-8dce-76f0304feda5");
        private readonly Guid classSubjectTeacherId44 = new Guid("864d4bfb-bf21-4e62-8097-8daf9b9beb99");
        private readonly Guid classSubjectTeacherId45 = new Guid("a86fc271-1ca2-4144-b79d-67d8fbf5051c");
        private readonly Guid classSubjectTeacherId46 = new Guid("c6f46afe-c62d-4c93-bea8-b5f95b691f0b");
        private readonly Guid classSubjectTeacherId47 = new Guid("6ddbe791-5add-411e-9b46-0aac3dfd8109");
        private readonly Guid classSubjectTeacherId48 = new Guid("af036f48-9af5-45b7-a274-49e608525480");
        #endregion

        #region ClassSubjectStudent

        private readonly Guid classSubjectStudentId1 = new Guid("a2f59575-4e37-48d3-81b6-261dddb51415");
        private readonly Guid classSubjectStudentId2 = new Guid("9b9543fd-ca79-4d88-b853-247242ca8bac");
        private readonly Guid classSubjectStudentId3 = new Guid("389a780e-3712-45df-89c8-55d930c90463");
        private readonly Guid classSubjectStudentId4 = new Guid("526fee77-f553-4748-8ebd-5672ae401be2");
        private readonly Guid classSubjectStudentId5 = new Guid("368e4d7b-5ba7-409c-8579-bbc32b48d668");
        private readonly Guid classSubjectStudentId6 = new Guid("d98e8a85-3192-48e4-ba56-3e79537d9355");
        private readonly Guid classSubjectStudentId7 = new Guid("a102912e-8a02-48b7-815b-a69b09006360");
        private readonly Guid classSubjectStudentId8 = new Guid("540a46ee-f7b1-4595-8e9d-e6802bbb7d0d");
        private readonly Guid classSubjectStudentId9 = new Guid("1f00b88d-97f3-4802-8e69-9f7ff23baace");
        private readonly Guid classSubjectStudentId10 = new Guid("0a11f0dd-c8d8-4300-ab05-669f2361d877");
        private readonly Guid classSubjectStudentId11 = new Guid("ebf42dfe-0f05-41e7-b48b-92c8b7d99d7d");
        private readonly Guid classSubjectStudentId12 = new Guid("e717d524-d12b-4683-a9c5-0164576c37eb");
        private readonly Guid classSubjectStudentId13 = new Guid("58ad4284-67dd-4b24-ac1b-2eab45f31393");
        private readonly Guid classSubjectStudentId14 = new Guid("9f203c85-5472-439e-a971-3b04f213f99f");
        private readonly Guid classSubjectStudentId15 = new Guid("26cbe11f-ee8d-4bd8-9db1-faa240837337");
        private readonly Guid classSubjectStudentId16 = new Guid("06df1fb9-3c7b-4ef5-af94-e2423c672e87");
        private readonly Guid classSubjectStudentId17 = new Guid("3493e1c2-6126-47d6-8205-01ed795383ad");
        private readonly Guid classSubjectStudentId18 = new Guid("eee4087b-7317-42bd-a55f-54ec7f922679");
        private readonly Guid classSubjectStudentId19 = new Guid("016763b1-fe31-4c2f-be88-6e549b6c178f");
        private readonly Guid classSubjectStudentId20 = new Guid("56dbdc3d-f1ef-4a80-9757-d1d61dbb32ef");
        private readonly Guid classSubjectStudentId21 = new Guid("dcc6549a-4899-4d82-9fd8-bef615a8c39e");
        private readonly Guid classSubjectStudentId22 = new Guid("3fab95c6-9fa4-449b-b1ef-4a4a4d415e23");
        private readonly Guid classSubjectStudentId23 = new Guid("2b0f30d4-55ab-4d07-89b8-23d44d9cc52f");
        private readonly Guid classSubjectStudentId24 = new Guid("99b01c37-2dbb-4677-86b9-d0010ae8c181");
        private readonly Guid classSubjectStudentId25 = new Guid("099186ec-340e-46b6-9bfa-941bf044f820");
        private readonly Guid classSubjectStudentId26 = new Guid("fb68e86e-5758-417a-97fe-e66a327d8a20");
        private readonly Guid classSubjectStudentId27 = new Guid("3536b281-86da-4450-b20e-3764d4377699");
        private readonly Guid classSubjectStudentId28 = new Guid("4a790d1c-b8db-41c6-ab26-a4402e698068");
        private readonly Guid classSubjectStudentId29 = new Guid("6d25a2d7-c0b2-4004-a0d2-045098c654b9");
        private readonly Guid classSubjectStudentId30 = new Guid("2acc1fb4-6354-4cb5-a0fc-aabea0c33dbe");
        private readonly Guid classSubjectStudentId31 = new Guid("96590e93-b3f5-465b-9066-b07d6a929615");
        private readonly Guid classSubjectStudentId32 = new Guid("e84eab9f-ec3c-4ee8-82d3-c642e274213f");
        private readonly Guid classSubjectStudentId33 = new Guid("171aa316-cee8-4174-a65c-6d5dc814856d");
        private readonly Guid classSubjectStudentId34 = new Guid("aa75e9ce-6626-460d-b25a-cd33d616d4f1");
        private readonly Guid classSubjectStudentId35 = new Guid("9519ce84-3211-4bfc-8261-bcdcbed9dc9e");
        private readonly Guid classSubjectStudentId36 = new Guid("a41769b6-f988-4196-b685-5e7720a18f97");
        private readonly Guid classSubjectStudentId37 = new Guid("fcfa0d01-6b4e-431d-a66a-760c2d1e4640");
        private readonly Guid classSubjectStudentId38 = new Guid("62569377-c4a8-43b1-99e4-14225a049a85");
        private readonly Guid classSubjectStudentId39 = new Guid("1bbd69c3-da14-467d-9bc4-2b7b19a3b845");
        private readonly Guid classSubjectStudentId40 = new Guid("0c6ff445-972d-47bf-bd3f-3886ebe3900b");
        private readonly Guid classSubjectStudentId41 = new Guid("b56144e2-2211-496f-87da-8d87ebc4aada");
        private readonly Guid classSubjectStudentId42 = new Guid("1332a19b-06a8-4375-a31d-cb0f1adc071a");
        private readonly Guid classSubjectStudentId43 = new Guid("01e5b760-3aff-450a-8a33-c44d4884805a");
        private readonly Guid classSubjectStudentId44 = new Guid("1bbb0362-ab0d-4a9e-8c6e-ffda9e007d19");
        private readonly Guid classSubjectStudentId45 = new Guid("ed60c2bf-dd14-4d41-b54c-31dd533b2e3a");
        private readonly Guid classSubjectStudentId46 = new Guid("fbb9b414-3d53-476d-83fb-cc955f3558fc");
        private readonly Guid classSubjectStudentId47 = new Guid("57d41ca5-27d6-44b6-ac8b-f350bf5b2215");
        private readonly Guid classSubjectStudentId48 = new Guid("10e585f5-cc9f-4ca7-9b3f-e570e7f186f2");
        private readonly Guid classSubjectStudentId49 = new Guid("d56d129d-4193-44b2-a337-283a0dc06400");
        private readonly Guid classSubjectStudentId50 = new Guid("3b5e7e6f-a965-4db0-9e61-2ce133df2bde");
        private readonly Guid classSubjectStudentId51 = new Guid("992affa3-55e8-4fdc-b30e-821984ecc532");
        private readonly Guid classSubjectStudentId52 = new Guid("b36e26bc-9fb8-470f-840c-d22f9dde229b");
        private readonly Guid classSubjectStudentId53 = new Guid("19a076c4-1efb-419e-bd76-adc95fd37cb2");
        private readonly Guid classSubjectStudentId54 = new Guid("88e3d7a1-9353-4c9c-bba1-140169e80602");
        private readonly Guid classSubjectStudentId55 = new Guid("fe6115fe-60e7-4997-9744-c174e5d650fa");
        private readonly Guid classSubjectStudentId56 = new Guid("1803f80d-a589-47c5-83a2-c9404a4310e1");
        private readonly Guid classSubjectStudentId57 = new Guid("dc61abe8-9127-4576-8dd6-60ab0817b89f");
        private readonly Guid classSubjectStudentId58 = new Guid("1a77d46c-d706-480c-9e3c-1fbbd43d2cd5");
        private readonly Guid classSubjectStudentId59 = new Guid("29e4dfa0-0f6b-400a-b5d1-1af9ccc8de1b");
        private readonly Guid classSubjectStudentId60 = new Guid("10ee7db5-3d01-44a2-aad5-302e06b14a3c");
        private readonly Guid classSubjectStudentId61 = new Guid("a40b789c-bdc0-486b-b9e4-4db93cf39b43");
        private readonly Guid classSubjectStudentId62 = new Guid("571a7733-bd16-4c73-81a5-8b2b48a89c3f");
        private readonly Guid classSubjectStudentId63 = new Guid("f5d70fd2-a7a2-4867-ba9d-5ade5e1c759b");
        private readonly Guid classSubjectStudentId64 = new Guid("b884c1d4-c1ce-47fb-8271-473304ee63c6");
        private readonly Guid classSubjectStudentId65 = new Guid("3540380d-dee4-461f-b1c4-94d0572f0b78");
        private readonly Guid classSubjectStudentId66 = new Guid("71b89643-21fa-47a5-a40d-81b1a6f1038b");
        private readonly Guid classSubjectStudentId67 = new Guid("a041ffc8-bd39-435d-928a-0b3ec033fff2");
        private readonly Guid classSubjectStudentId68 = new Guid("04798c75-751b-4dd2-bc3c-7402c965ac1a");
        private readonly Guid classSubjectStudentId69 = new Guid("2f9939ca-c9c9-4ca9-9dbe-9be473d1bdda");
        private readonly Guid classSubjectStudentId70 = new Guid("c7829b7c-eb46-4303-9595-b94a7d357269");
        private readonly Guid classSubjectStudentId71 = new Guid("4a3cc0c1-f153-4bd0-bac4-9bcf4aef1424");
        private readonly Guid classSubjectStudentId72 = new Guid("7b6ba744-1e0b-456c-a71c-5c8cbb2335a8");
        private readonly Guid classSubjectStudentId73 = new Guid("ddc7364d-626f-4de2-a28e-ddef746935e3");
        private readonly Guid classSubjectStudentId74 = new Guid("8377dfac-d04b-4f8e-ab1c-6ca22eb18520");
        private readonly Guid classSubjectStudentId75 = new Guid("d50f0806-f530-416d-ae2f-17da89b25caa");
        private readonly Guid classSubjectStudentId76 = new Guid("0cb1b3b2-f028-47d0-8985-73546a654599");
        private readonly Guid classSubjectStudentId77 = new Guid("fa51c9ad-8fcf-4127-904e-0f0f0d7b1cab");
        private readonly Guid classSubjectStudentId78 = new Guid("3110cdd0-76d6-4f1d-92a5-6fa141683f12");
        private readonly Guid classSubjectStudentId79 = new Guid("28bed177-d626-46a2-8626-4ab50a6b4201");
        private readonly Guid classSubjectStudentId80 = new Guid("2743d1b6-e475-45fa-a87a-5d05df9faa82");
        private readonly Guid classSubjectStudentId81 = new Guid("6c730bd0-0860-49fa-be98-f44161aabe3b");
        private readonly Guid classSubjectStudentId82 = new Guid("9ba965a2-7afe-4a3e-bb66-d4dfcf05adbc");
        private readonly Guid classSubjectStudentId83 = new Guid("bedf8adf-3ffe-48dd-8faf-8262959eea81");
        private readonly Guid classSubjectStudentId84 = new Guid("e4d5660a-9231-4d4a-80f1-f6e57d4884da");
        private readonly Guid classSubjectStudentId85 = new Guid("90edce61-b096-4b77-a3bc-f155b411ee9e");
        private readonly Guid classSubjectStudentId86 = new Guid("a3681297-272b-4757-9d48-c9f0af1f4324");
        private readonly Guid classSubjectStudentId87 = new Guid("74749268-323c-44ee-8995-980d5c26aa8f");
        private readonly Guid classSubjectStudentId88 = new Guid("ba7c80b4-43e7-4178-80d9-fdbbfafc0593");
        private readonly Guid classSubjectStudentId89 = new Guid("74858ed0-cc91-4076-87aa-a9770eff4259");
        private readonly Guid classSubjectStudentId90 = new Guid("3cb32df4-8829-4aa8-8a63-7a8f7eb5d24b");
        private readonly Guid classSubjectStudentId91 = new Guid("162f0273-2f0e-46d9-86c4-b35d6619fb55");
        private readonly Guid classSubjectStudentId92 = new Guid("fd896362-a273-4a4a-8103-cc69e379168b");
        private readonly Guid classSubjectStudentId93 = new Guid("6642f5be-26b5-458d-85ee-4f4ba1d4dc77");
        private readonly Guid classSubjectStudentId94 = new Guid("e6b15032-6a9c-4b1e-bfdb-8a32e18b733d");
        private readonly Guid classSubjectStudentId95 = new Guid("1d98b213-5472-4ce7-93f4-6cd384dbab9b");
        private readonly Guid classSubjectStudentId96 = new Guid("88791298-78d8-4dc3-a4b8-220325806ba8");
        private readonly Guid classSubjectStudentId97 = new Guid("94ca9719-5577-4892-b29d-065b282bbffd");
        private readonly Guid classSubjectStudentId98 = new Guid("4f354910-a939-452f-9764-7350f2057c83");
        private readonly Guid classSubjectStudentId99 = new Guid("c4900e11-8212-46a1-8c6a-c2a775f9f510");
        private readonly Guid classSubjectStudentId100 = new Guid("fb7db125-313a-4c9a-a083-a0896ad52ea7");
        private readonly Guid classSubjectStudentId101 = new Guid("3d3cdd47-e828-4fd1-bfe0-d1713b040b1f");
        private readonly Guid classSubjectStudentId102 = new Guid("4bb21f54-4733-48b6-aebc-994ef9fb988a");
        private readonly Guid classSubjectStudentId103 = new Guid("3ddaca1f-dceb-4410-a21d-555a1a67591b");
        private readonly Guid classSubjectStudentId104 = new Guid("9429698b-3634-4ab0-8c2c-e42e999e3ae4");
        private readonly Guid classSubjectStudentId105 = new Guid("ad288f02-a3ee-4776-b2b1-3d394976025a");
        private readonly Guid classSubjectStudentId106 = new Guid("e17464aa-8326-4b65-8167-3a00ed3ed75b");
        private readonly Guid classSubjectStudentId107 = new Guid("fe019398-a4fc-436c-809c-3777b160a593");
        private readonly Guid classSubjectStudentId108 = new Guid("c6a56e00-a664-4d57-abf8-6aa7449b69cd");
        private readonly Guid classSubjectStudentId109 = new Guid("528bd666-c3df-47f3-a655-8a553d5e1152");
        private readonly Guid classSubjectStudentId110 = new Guid("428600a5-86ed-4d6d-b464-40cf2304a543");
        private readonly Guid classSubjectStudentId111 = new Guid("37a34646-e6f1-4de0-9fa2-e62cad88b904");
        private readonly Guid classSubjectStudentId112 = new Guid("fee203c2-7699-469d-924e-6259ead7f79f");
        private readonly Guid classSubjectStudentId113 = new Guid("0d6a8bd0-7114-4917-bab0-ac137f8e98cd");
        private readonly Guid classSubjectStudentId114 = new Guid("4fa7e9aa-9412-4ca6-9a52-90b691000457");
        private readonly Guid classSubjectStudentId115 = new Guid("d78b2df2-2586-4c3a-aab0-dddd60424489");
        private readonly Guid classSubjectStudentId116 = new Guid("261817f4-08d8-4c35-99de-d281ac20e1d5");
        private readonly Guid classSubjectStudentId117 = new Guid("94284d7b-980d-4302-ad31-9d0d70a377ef");
        private readonly Guid classSubjectStudentId118 = new Guid("4e988571-33c7-43a6-b5ba-eb5e0b2d5832");
        private readonly Guid classSubjectStudentId119 = new Guid("c6b14a67-b4a1-4c1d-b0ee-69466ee2d1d7");
        private readonly Guid classSubjectStudentId120 = new Guid("aa5aa512-cae9-44f7-9de2-15e25f6c5323");

        #endregion

        #region ClassSubject
        private readonly Guid classSubjectId1 = new Guid("4c6fe73b-8e2e-4a4e-8645-25a7fc85db63");
        private readonly Guid classSubjectId2 = new Guid("b08901ad-51d8-48ae-b2d5-e65c7eece0ae");
        private readonly Guid classSubjectId3 = new Guid("f20e400f-e05a-418f-b08d-4663b2ba0e22");
        private readonly Guid classSubjectId4 = new Guid("3d55eb70-aeec-4aae-9aaa-3c4d568a6d30");
        private readonly Guid classSubjectId5 = new Guid("a0c43464-473e-4db7-a61b-a8aaf036aafe");
        private readonly Guid classSubjectId6 = new Guid("c0d25057-649e-41ec-bb70-b57da2cfab2b");
        private readonly Guid classSubjectId7 = new Guid("daa9a15a-f07f-4df2-9151-4a4de7110cb3");
        private readonly Guid classSubjectId8 = new Guid("a77bb839-07bc-47ba-b28b-e41fa355a35b");
        private readonly Guid classSubjectId9 = new Guid("686cf848-8cda-4791-85f7-43e25fb7db5c");
        private readonly Guid classSubjectId10 = new Guid("17cb3e61-7593-4a52-81ec-4b5db0d0489e");
        private readonly Guid classSubjectId11 = new Guid("bc8a83f2-18f7-44ad-ac60-cfe4ad601fdf");
        private readonly Guid classSubjectId12 = new Guid("f82b3dd9-3439-4d65-a000-10dd2128119c");
        private readonly Guid classSubjectId13 = new Guid("c8aefee3-2ce0-4d30-9278-214dbc2dbb17");
        private readonly Guid classSubjectId14 = new Guid("5c27a09c-3a37-421e-a0ce-b202444e1ce2");
        private readonly Guid classSubjectId15 = new Guid("ef57ba16-74a6-41a8-9066-193a91e9e34b");
        private readonly Guid classSubjectId16 = new Guid("bcf2b1ea-77ca-4159-b4b9-da052a285b0a");
        private readonly Guid classSubjectId17 = new Guid("74b1463d-8c0f-489b-b3bd-b551ee7341aa");
        private readonly Guid classSubjectId18 = new Guid("d9450901-d7bc-4cd3-b22c-80ea45717269");
        private readonly Guid classSubjectId19 = new Guid("48fde1ff-9b08-47d8-ae7b-635be6f0baef");
        private readonly Guid classSubjectId20 = new Guid("60e3c648-d922-413c-b82d-c6d6adde68a8");
        private readonly Guid classSubjectId21 = new Guid("15940a61-05bd-4aae-bdae-7b84776ddb9d");
        private readonly Guid classSubjectId22 = new Guid("fbb2a2a4-7b80-4f55-aff3-d2f6aeee8357");
        private readonly Guid classSubjectId23 = new Guid("907dddc1-f73b-43b2-92b2-66dd9a568c0f");
        private readonly Guid classSubjectId24 = new Guid("30bd9a53-d023-4bd1-9a40-496c7c53ffe8");
        private readonly Guid classSubjectId25 = new Guid("9bf39ddc-8e11-4424-8059-bbd2bfac9f27");
        private readonly Guid classSubjectId26 = new Guid("e85e931f-4f8a-470d-97e7-165fb016fa46");
        private readonly Guid classSubjectId27 = new Guid("a3b2767f-4549-45da-bc14-73841f9adebe");
        private readonly Guid classSubjectId28 = new Guid("e8c5516b-327b-44f2-95a7-89841b972afe");
        private readonly Guid classSubjectId29 = new Guid("829c3596-46a7-44e7-b656-546760543111");
        private readonly Guid classSubjectId30 = new Guid("e7ad8e52-02f8-4e0e-a93a-76c85434b931");
        private readonly Guid classSubjectId31 = new Guid("9a81a387-51f1-4cb3-a7da-5b7d4e4f2af4");
        private readonly Guid classSubjectId32 = new Guid("ffb6e551-a54b-4a89-9b89-00659e711f2e");
        private readonly Guid classSubjectId33 = new Guid("3e6e883c-ff6c-4b27-ae1f-6ff00b2ff0e3");
        private readonly Guid classSubjectId34 = new Guid("a10238c0-690f-4c51-aaaa-b4fc5c6a18fc");
        private readonly Guid classSubjectId35 = new Guid("4c76b425-dd0a-497b-b03c-4989458fa326");
        private readonly Guid classSubjectId36 = new Guid("2b6469fc-913e-4000-b51f-4d859d30e76f");
        private readonly Guid classSubjectId37 = new Guid("5b5f515f-8990-495d-b948-a4013494c365");
        private readonly Guid classSubjectId38 = new Guid("2426db38-658d-403f-8563-c83a07fded38");
        private readonly Guid classSubjectId39 = new Guid("ae08ca5f-b8c4-4aaa-b727-6080ac27122e");
        private readonly Guid classSubjectId40 = new Guid("63de929f-7148-4b46-ab1e-bbfac30a570f");
        private readonly Guid classSubjectId41 = new Guid("47e472bc-07c4-4350-b46c-839ebd7555d8");
        private readonly Guid classSubjectId42 = new Guid("4e80a7f7-d5a8-4fb2-a90e-cc53d6cc8d70");
        private readonly Guid classSubjectId43 = new Guid("c2620ffd-9aa0-4f8e-b5ed-1d4500d26212");
        private readonly Guid classSubjectId44 = new Guid("bac7468d-cf42-44f3-9291-da89bbc176fc");
        private readonly Guid classSubjectId45 = new Guid("5a1edab5-0341-4332-9580-9838d7d08b8b");
        private readonly Guid classSubjectId46 = new Guid("5672066b-b3d2-4360-8032-9f0b843bf9ca");
        private readonly Guid classSubjectId47 = new Guid("37e13020-b0f8-4172-8f56-8a000c27220b");
        private readonly Guid classSubjectId48 = new Guid("85cd8459-ffe4-4ac1-bde1-5de59aaf59e5");

        #endregion

        #region Teacher
        private readonly Guid teacherId1 = new Guid("09458a6c-d313-4bee-b66f-19c0ff543c44");
        private readonly Guid teacherId2 = new Guid("0218e6c6-9b1c-44c3-9ac2-95b2fda929f7");
        private readonly Guid teacherId3 = new Guid("77a14da8-1caa-4ad0-9cd3-4208cfc3ac66");
        private readonly Guid teacherId4 = new Guid("39b703bc-9cc0-4974-be21-cf4327e9f6b4");
        private readonly Guid teacherId5 = new Guid("953785b4-12d2-4ca0-a65e-70230c5880c5");
        private readonly Guid teacherId6 = new Guid("8bc1831c-1c7f-4a43-a04b-3aae0a7bfe7d");
        private readonly Guid teacherId7 = new Guid("5d6e3425-d473-47e0-b20d-6ac256c1baa9");
        private readonly Guid teacherId8 = new Guid("8b1f6bae-fe3e-4cca-9bfa-6ff4856bf790");
        private readonly Guid teacherId9 = new Guid("d455d687-5783-490c-abf3-92ea550fb2f6");
        private readonly Guid teacherId10 = new Guid("a5649831-2968-4985-a3d2-08025ec365a6");
        private readonly Guid teacherId11 = new Guid("62d4224a-f21d-4adc-9826-e12ed32af95e");
        private readonly Guid teacherId12 = new Guid("29861f16-863d-415d-9965-8f0ac0dbb0d7");
        private readonly Guid teacherId13 = new Guid("6c96331c-aa01-47e6-9aa7-9ebe3d23a527");
        private readonly Guid teacherId14 = new Guid("70b43a46-90a4-4154-a977-9de8cb3d6464");
        private readonly Guid teacherId15 = new Guid("507b51fa-905f-4d00-a6df-f1c68608c3a4");
        private readonly Guid teacherId16 = new Guid("148b8e31-7684-4974-bde4-744c9171f606");
        #endregion

        #region Student
        private readonly Guid studentId1 = new Guid("aca69ac4-2bd2-4d9b-b84f-56a0793d9f40");
        private readonly Guid studentId2 = new Guid("7f588c68-3fa5-4fbf-b9af-a21f1656c957");
        private readonly Guid studentId3 = new Guid("6e1ec7d1-8311-410d-850a-9cbdaf598728");
        private readonly Guid studentId4 = new Guid("692c94cf-fb77-43a8-a0ff-734770cf5078");
        private readonly Guid studentId5 = new Guid("5162685a-869f-49d5-8d8a-6956f032344d");
        private readonly Guid studentId6 = new Guid("7bf293b0-b5b6-4538-b0dc-80479d473c3e");
        private readonly Guid studentId7 = new Guid("46b55249-3dba-4ca7-8786-75c12bc9a5c9");
        private readonly Guid studentId8 = new Guid("077875b7-5198-41e1-b3b7-d3345b8c82f2");
        private readonly Guid studentId9 = new Guid("23ee9929-0324-47b1-979e-cb8a334bd8c9");
        private readonly Guid studentId10 = new Guid("984af5e6-48b8-4396-a2a3-ec4ae7015062");
        private readonly Guid studentId11 = new Guid("b6a95766-3422-4ede-920a-eee089028323");
        private readonly Guid studentId12 = new Guid("e97266a3-c160-448e-a1b9-985bef7385dd");
        private readonly Guid studentId13 = new Guid("500a3272-daf2-41a0-afe1-06e50bb7dbb2");
        private readonly Guid studentId14 = new Guid("67da72fb-74fc-4dcc-b817-feee349eb68a");
        private readonly Guid studentId15 = new Guid("19d39def-272a-4cc3-bbc0-b62b95b504c4");
        private readonly Guid studentId16 = new Guid("00fab99e-3c20-4b31-b52d-ab3dce9087d5");
        private readonly Guid studentId17 = new Guid("b8461da6-29cf-40f8-aef7-41fb547b180f");
        private readonly Guid studentId18 = new Guid("89d27a99-96ce-4798-96c9-8b3693b4396d");
        private readonly Guid studentId19 = new Guid("21504568-db0b-4585-8571-61fb45e7a591");
        private readonly Guid studentId20 = new Guid("8b57255a-25fa-4271-ac00-b113b3f5a075");
        private readonly Guid studentId21 = new Guid("01c21eae-856c-44cc-a70c-4e45c17e4e9c");
        private readonly Guid studentId22 = new Guid("a3c8e25b-b512-434b-8fa3-0e66ffa41c2c");
        private readonly Guid studentId23 = new Guid("fe003217-07db-4f75-8cb5-1502a080eed4");
        private readonly Guid studentId24 = new Guid("a38bf59f-bea4-454f-8467-2b253087c319");
        private readonly Guid studentId25 = new Guid("b756d61f-eac9-4fbd-bfd0-256e86b803b6");
        private readonly Guid studentId26 = new Guid("8144c05d-0eee-4135-97c0-a67271de0379");
        private readonly Guid studentId27 = new Guid("a841a47c-7a8f-4d57-9323-f2e88a3801bc");
        private readonly Guid studentId28 = new Guid("4098aebd-284e-4d6d-b321-c773eb564a06");
        private readonly Guid studentId29 = new Guid("ba2113ba-15d1-4f60-bd05-76e53606204b");
        private readonly Guid studentId30 = new Guid("3d8b6dd9-d316-4c0c-a162-43d4e7d37f87");
        private readonly Guid studentId31 = new Guid("a36998d9-2d64-403d-8010-f85a1e223234");
        private readonly Guid studentId32 = new Guid("7edbb423-f7d8-42ea-9457-e161b73e2bb7");
        private readonly Guid studentId33 = new Guid("67351ad7-7cbf-4bfa-b786-f0ee9039b9f8");
        private readonly Guid studentId34 = new Guid("b613f2bd-af52-43a3-9b92-da5f88d53481");
        private readonly Guid studentId35 = new Guid("f6526308-8de0-4f68-bca3-84e4fc72a1b6");
        private readonly Guid studentId36 = new Guid("5c9b57aa-3fd1-4eda-8707-289dee52ce74");
        private readonly Guid studentId37 = new Guid("178e6f7c-a8e0-4f81-9c4e-5d6f565082e3");
        private readonly Guid studentId38 = new Guid("67e57dd9-0a7b-41c0-bf18-d75247ec3e9e");
        private readonly Guid studentId39 = new Guid("53bbdbb2-a8f9-4277-bde5-8fe312def5df");
        private readonly Guid studentId40 = new Guid("3616fb89-0ce7-4959-a9d7-13aea5f0b6b4");
        private readonly Guid studentId41 = new Guid("7026fdf8-9a5c-41db-a206-90181ac2d0fa");
        private readonly Guid studentId42 = new Guid("afb29af0-d2af-4c26-9fde-2f603c785fdb");
        private readonly Guid studentId43 = new Guid("7479d023-f07f-4439-bd10-f8e0a580b030");
        private readonly Guid studentId44 = new Guid("fd873b40-10a4-40bb-9a0f-1fbdc6e7c9be");
        private readonly Guid studentId45 = new Guid("2b55b5ce-b5dd-4f98-8a7e-f81eed04ea58");
        private readonly Guid studentId46 = new Guid("bbbb868c-5041-43ce-a83a-6d098531aeb9");
        private readonly Guid studentId47 = new Guid("ce00edbb-2403-41f5-b4d1-05c374421381");
        private readonly Guid studentId48 = new Guid("1c53824a-5263-4b56-a114-520090f99378");
        private readonly Guid studentId49 = new Guid("7ae99302-dfc6-49b9-b4bd-17960ea77d83");
        private readonly Guid studentId50 = new Guid("43c6ecce-a7ad-4477-8a91-8bd45b2f55b2");
        private readonly Guid studentId51 = new Guid("59e69c5a-0fef-445d-bb43-f29a024a2c3b");
        private readonly Guid studentId52 = new Guid("255fc014-878d-4cac-abd0-8947be6bb8ec");
        private readonly Guid studentId53 = new Guid("5f690c82-1771-4931-be84-0833d67b9a35");
        private readonly Guid studentId54 = new Guid("c15fb460-efa6-4582-af21-a1651fd6d14f");
        private readonly Guid studentId55 = new Guid("39daaf9f-d650-456d-97e1-8fe5186059eb");
        private readonly Guid studentId56 = new Guid("796ae0df-8485-41cd-b3cf-431f1fc138b4");
        private readonly Guid studentId57 = new Guid("eb2f86c7-e5d3-4919-bf3b-0ec90faca990");
        private readonly Guid studentId58 = new Guid("a7521676-f3a8-47cb-acef-d67df115d281");
        private readonly Guid studentId59 = new Guid("ec8265e8-c976-441f-a648-e90738eb334b");
        private readonly Guid studentId60 = new Guid("41968e63-3e0c-45f6-9b33-8c2943b6209f");
        #endregion


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassSubjectTeacher",
                columns: ["Id", "ClassSubjectId", "TeacherId"],
                values: new object[,]
               {
                    { classSubjectTeacherId1, classSubjectId1, teacherId1 },
                    { classSubjectTeacherId2, classSubjectId2, teacherId2 },
                    { classSubjectTeacherId3, classSubjectId3, teacherId3 },
                    { classSubjectTeacherId4, classSubjectId4, teacherId4 },
                    { classSubjectTeacherId5, classSubjectId5, teacherId5 },
                    { classSubjectTeacherId6, classSubjectId6, teacherId6 },
                    { classSubjectTeacherId7, classSubjectId7, teacherId7 },
                    { classSubjectTeacherId8, classSubjectId8, teacherId8 },

                    { classSubjectTeacherId9, classSubjectId9, teacherId1 },
                    { classSubjectTeacherId10, classSubjectId10, teacherId2 },
                    { classSubjectTeacherId11, classSubjectId11, teacherId3 },
                    { classSubjectTeacherId12, classSubjectId12, teacherId4 },
                    { classSubjectTeacherId13, classSubjectId13, teacherId5 },
                    { classSubjectTeacherId14, classSubjectId14, teacherId6 },
                    { classSubjectTeacherId15, classSubjectId15, teacherId7 },
                    { classSubjectTeacherId16, classSubjectId16, teacherId8 },

                    { classSubjectTeacherId17, classSubjectId17, teacherId1 },
                    { classSubjectTeacherId18, classSubjectId18, teacherId2 },
                    { classSubjectTeacherId19, classSubjectId19, teacherId3 },
                    { classSubjectTeacherId20, classSubjectId20, teacherId4 },
                    { classSubjectTeacherId21, classSubjectId21, teacherId5 },
                    { classSubjectTeacherId22, classSubjectId22, teacherId6 },
                    { classSubjectTeacherId23, classSubjectId23, teacherId7 },
                    { classSubjectTeacherId24, classSubjectId24, teacherId8 },

                    { classSubjectTeacherId25, classSubjectId25, teacherId9 },
                    { classSubjectTeacherId26, classSubjectId26, teacherId10 },
                    { classSubjectTeacherId27, classSubjectId27, teacherId11 },
                    { classSubjectTeacherId28, classSubjectId28, teacherId12 },
                    { classSubjectTeacherId29, classSubjectId29, teacherId13 },
                    { classSubjectTeacherId30, classSubjectId30, teacherId14 },
                    { classSubjectTeacherId31, classSubjectId31, teacherId15 },
                    { classSubjectTeacherId32, classSubjectId32, teacherId16 },

                    { classSubjectTeacherId33, classSubjectId33, teacherId9 },
                    { classSubjectTeacherId34, classSubjectId34, teacherId10 },
                    { classSubjectTeacherId35, classSubjectId35, teacherId11 },
                    { classSubjectTeacherId36, classSubjectId36, teacherId12 },
                    { classSubjectTeacherId37, classSubjectId37, teacherId13 },
                    { classSubjectTeacherId38, classSubjectId38, teacherId14 },
                    { classSubjectTeacherId39, classSubjectId39, teacherId15 },
                    { classSubjectTeacherId40, classSubjectId40, teacherId16 },

                    { classSubjectTeacherId41, classSubjectId41, teacherId9 },
                    { classSubjectTeacherId42, classSubjectId42, teacherId10 },
                    { classSubjectTeacherId43, classSubjectId43, teacherId11 },
                    { classSubjectTeacherId44, classSubjectId44, teacherId12 },
                    { classSubjectTeacherId45, classSubjectId45, teacherId13 },
                    { classSubjectTeacherId46, classSubjectId46, teacherId14 },
                    { classSubjectTeacherId47, classSubjectId47, teacherId15 },
                    { classSubjectTeacherId48, classSubjectId48, teacherId16 }
               }
            );

            migrationBuilder.InsertData(
                schema: "User",
                table: "ClassSubjectStudent",
                columns: ["Id", "ClassSubjectId", "StudentId"],
                values: new object[,]
                {
                    { classSubjectStudentId1, classSubjectId41, studentId1 },
                    { classSubjectStudentId2, classSubjectId41, studentId2 },
                    { classSubjectStudentId3, classSubjectId41, studentId3  },
                    { classSubjectStudentId4, classSubjectId41, studentId4  },
                    { classSubjectStudentId5, classSubjectId42, studentId5  },
                    { classSubjectStudentId6, classSubjectId42, studentId1  },
                    { classSubjectStudentId7, classSubjectId43, studentId2  },
                    { classSubjectStudentId8, classSubjectId43, studentId3  },
                    { classSubjectStudentId9, classSubjectId44, studentId4  },
                    { classSubjectStudentId10, classSubjectId44, studentId5  },

                    { classSubjectStudentId11, classSubjectId45, studentId6  },
                    { classSubjectStudentId12, classSubjectId45, studentId7  },
                    { classSubjectStudentId13, classSubjectId45, studentId8  },
                    { classSubjectStudentId14, classSubjectId45, studentId9  },
                    { classSubjectStudentId15, classSubjectId46, studentId10  },
                    { classSubjectStudentId16, classSubjectId46, studentId6  },
                    { classSubjectStudentId17, classSubjectId47, studentId7  },
                    { classSubjectStudentId18, classSubjectId47, studentId8  },
                    { classSubjectStudentId19, classSubjectId48, studentId9  },
                    { classSubjectStudentId20, classSubjectId48, studentId10  },

                    { classSubjectStudentId21, classSubjectId33, studentId11 },
                    { classSubjectStudentId22, classSubjectId33, studentId12 },
                    { classSubjectStudentId23, classSubjectId33, studentId13 },
                    { classSubjectStudentId24, classSubjectId33, studentId14 },
                    { classSubjectStudentId25, classSubjectId34, studentId15 },
                    { classSubjectStudentId26, classSubjectId34, studentId11 },
                    { classSubjectStudentId27, classSubjectId35, studentId12 },
                    { classSubjectStudentId28, classSubjectId35, studentId13 },
                    { classSubjectStudentId29, classSubjectId36, studentId14 },
                    { classSubjectStudentId30, classSubjectId36, studentId15 },

                    { classSubjectStudentId31, classSubjectId37, studentId16 },
                    { classSubjectStudentId32, classSubjectId37, studentId17 },
                    { classSubjectStudentId33, classSubjectId37, studentId18 },
                    { classSubjectStudentId34, classSubjectId37, studentId19 },
                    { classSubjectStudentId35, classSubjectId38, studentId20 },
                    { classSubjectStudentId36, classSubjectId38, studentId16 },
                    { classSubjectStudentId37, classSubjectId39, studentId17 },
                    { classSubjectStudentId38, classSubjectId39, studentId18 },
                    { classSubjectStudentId39, classSubjectId40, studentId19 },
                    { classSubjectStudentId40, classSubjectId40, studentId20 },

                    { classSubjectStudentId41, classSubjectId25, studentId21 },
                    { classSubjectStudentId42, classSubjectId25, studentId22 },
                    { classSubjectStudentId43, classSubjectId25, studentId23 },
                    { classSubjectStudentId44, classSubjectId25, studentId24 },
                    { classSubjectStudentId45, classSubjectId26, studentId25 },
                    { classSubjectStudentId46, classSubjectId26, studentId21 },
                    { classSubjectStudentId47, classSubjectId27, studentId22 },
                    { classSubjectStudentId48, classSubjectId27, studentId23 },
                    { classSubjectStudentId49, classSubjectId28, studentId24 },
                    { classSubjectStudentId50, classSubjectId28, studentId25 },

                    { classSubjectStudentId51, classSubjectId29, studentId26 },
                    { classSubjectStudentId52, classSubjectId29, studentId27 },
                    { classSubjectStudentId53, classSubjectId29, studentId28 },
                    { classSubjectStudentId54, classSubjectId29, studentId29 },
                    { classSubjectStudentId55, classSubjectId30, studentId30 },
                    { classSubjectStudentId56, classSubjectId30, studentId26 },
                    { classSubjectStudentId57, classSubjectId31, studentId27 },
                    { classSubjectStudentId58, classSubjectId31, studentId28 },
                    { classSubjectStudentId59, classSubjectId32, studentId29 },
                    { classSubjectStudentId60, classSubjectId32, studentId30 },

                    { classSubjectStudentId61, classSubjectId17, studentId31 },
                    { classSubjectStudentId62, classSubjectId17, studentId32 },
                    { classSubjectStudentId63, classSubjectId17, studentId33 },
                    { classSubjectStudentId64, classSubjectId17, studentId34 },
                    { classSubjectStudentId65, classSubjectId18, studentId35 },
                    { classSubjectStudentId66, classSubjectId18, studentId31 },
                    { classSubjectStudentId67, classSubjectId19, studentId32 },
                    { classSubjectStudentId68, classSubjectId19, studentId33 },
                    { classSubjectStudentId69, classSubjectId20, studentId34 },
                    { classSubjectStudentId70, classSubjectId20, studentId35 },

                    { classSubjectStudentId71, classSubjectId21, studentId36 },
                    { classSubjectStudentId72, classSubjectId21, studentId37 },
                    { classSubjectStudentId73, classSubjectId21, studentId38 },
                    { classSubjectStudentId74, classSubjectId21, studentId39 },
                    { classSubjectStudentId75, classSubjectId22, studentId40 },
                    { classSubjectStudentId76, classSubjectId22, studentId36 },
                    { classSubjectStudentId77, classSubjectId23, studentId37 },
                    { classSubjectStudentId78, classSubjectId23, studentId38 },
                    { classSubjectStudentId79, classSubjectId24, studentId39 },
                    { classSubjectStudentId80, classSubjectId24, studentId40 },

                    { classSubjectStudentId81, classSubjectId9, studentId41 },
                    { classSubjectStudentId82, classSubjectId9, studentId42 },
                    { classSubjectStudentId83, classSubjectId9, studentId43 },
                    { classSubjectStudentId84, classSubjectId9, studentId44 },
                    { classSubjectStudentId85, classSubjectId10, studentId45 },
                    { classSubjectStudentId86, classSubjectId10, studentId41 },
                    { classSubjectStudentId87, classSubjectId11, studentId42 },
                    { classSubjectStudentId88, classSubjectId11, studentId43 },
                    { classSubjectStudentId89, classSubjectId12, studentId44 },
                    { classSubjectStudentId90, classSubjectId12, studentId45 },

                    { classSubjectStudentId91, classSubjectId13, studentId46 },
                    { classSubjectStudentId92, classSubjectId13, studentId47 },
                    { classSubjectStudentId93, classSubjectId13, studentId48 },
                    { classSubjectStudentId94, classSubjectId13, studentId49 },
                    { classSubjectStudentId95, classSubjectId14, studentId50 },
                    { classSubjectStudentId96, classSubjectId14, studentId46 },
                    { classSubjectStudentId97, classSubjectId15, studentId47 },
                    { classSubjectStudentId98, classSubjectId15, studentId48 },
                    { classSubjectStudentId99, classSubjectId16, studentId49 },
                    { classSubjectStudentId100, classSubjectId16, studentId50 },

                    { classSubjectStudentId101, classSubjectId1, studentId51 },
                    { classSubjectStudentId102, classSubjectId1, studentId52 },
                    { classSubjectStudentId103, classSubjectId1, studentId53 },
                    { classSubjectStudentId104, classSubjectId1, studentId54 },
                    { classSubjectStudentId105, classSubjectId2, studentId55 },
                    { classSubjectStudentId106, classSubjectId2, studentId51 },
                    { classSubjectStudentId107, classSubjectId3, studentId52 },
                    { classSubjectStudentId108, classSubjectId3, studentId53 },
                    { classSubjectStudentId109, classSubjectId4, studentId54 },
                    { classSubjectStudentId110, classSubjectId4, studentId55 },

                    { classSubjectStudentId111, classSubjectId5, studentId56 },
                    { classSubjectStudentId112, classSubjectId5, studentId57 },
                    { classSubjectStudentId113, classSubjectId5, studentId58 },
                    { classSubjectStudentId114, classSubjectId5, studentId59 },
                    { classSubjectStudentId115, classSubjectId6, studentId60 },
                    { classSubjectStudentId116, classSubjectId6, studentId56 },
                    { classSubjectStudentId117, classSubjectId7, studentId57 },
                    { classSubjectStudentId118, classSubjectId7, studentId58 },
                    { classSubjectStudentId119, classSubjectId8, studentId59 },
                    { classSubjectStudentId120, classSubjectId8, studentId60 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
