using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucene.Net;
using Lucene.Net.Documents;
using Lucene.Net.Store;


namespace WindowsFormsApplication3
{
    class LuceneClass
    {
        public Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));
        public Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);
        //public Lucene.Net.Index.IndexReader indexReader = Lucene.Net.Index.IndexReader.Open(directory, true);
        //public Lucene.Net.Search.Searcher indexSearch = new Lucene.Net.Search.IndexSearcher(indexReader);

        public LuceneClass()
        {
            Document[] Doc = new Document[11];
            for(int i = 0; i < 10; i++)
            {
                Doc[i] = new Document();
            }

            DataSet(Doc);
            

            var writer = new Lucene.Net.Index.IndexWriter(directory, analyzer, true, Lucene.Net.Index.IndexWriter.MaxFieldLength.LIMITED);

            for (int i = 0; i < 10; i++)
            {
                writer.AddDocument(Doc[i]);
            }
            
            writer.Optimize();
            writer.Close();
        }

        public void DataSet (Document[] Doc)
        {
            Doc[0].Add(new Field("Id", "1", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("name", "검은 별 무늬 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("symptom", "잎 갈색 ~ 녹갈색 의 반점 이 생기고 그 뒷면에 흑녹색 의 포자 가 생긴다. 잎 표면 에 병반 이 형성 되면 그 부분이 융기 되고 잎 이 기형 으로 된다. 잎자루 에 발병 된 잎은 황화 (黃化) 되어 조기 낙엽 된다. 감염 후 병반 에서 포자 형성 까지는 7~ 18일이 필요 하다. 과실 에서는 유과기 (幼 果期) 에 발병 되고 흑색 의 소반점 이 형성 된 후 확대 되면서 기형과 가 되고 균열 된다- 가지 에서도 발생 하나 특히 발병 이 심한 경우를 제외 하고는 많지 않다. 가지 의 표면 이 거칠고 표피 가 파괴 되는 흑색 병반 이 형성 된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("symptom1", "잎에는 처음 갈색~녹갈색의 반점이 생기고 그 뒷면에 흑녹색의 포자가 생긴다. 잎 표면에 병반이 형성되면 그 부분이 융기되고 잎이 기형으로 된다. 잎자루에 발병된 잎은 황화(黃化)되어 조기낙엽 된다. 감염 후 병반에서 포자형성까지는 7~ 18일이 필요하다. 과실에서는 유과기 (幼 果期)에 발병되고 흑색의 소반점이 형성된 후 확대되면서 기형과가 되고 균열된다- 가지에서도 발생하나 특히 발병이 심한 경우를 제외하고는 많지 않다. 가지의 표면이 거칠고 표피가 파괴되는 흑색 병반이 형성된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("species", "사과", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("ecology", "자낭균 에 속하며 자낭포자 및 분생포자를 형성한다. 병든 잎, 병든 가지 의 인편 에 형성 된 자낭 포자 나 분생 포자 가 월동 하여 1차 전염원 이 된다. 피해 낙엽 에서는 이듬해 봄 에 자낭각, 자낭，자낭포자 순으로 성숙 된다. 비가 온 후 자낭각 에서 자낭 포자 가 비산 되어 잎 이나 과실 에 침입 ，발병 한다. 자낭포자 는 개화 직전 부터 낙화 20일까지 비 산되는 량이 많다. 병반상 에 형성 된 분생 포자 는 비에 의해 비산 되어 2차 감염 한다. 8월 이후에 감염 된 과실 은 수확 시에 병반 을 나타내지 않고 저장 중에 발병 하는 경우 도 있다. 발생 은 5월 중순 부터 발병 하기 시작 하여 장마기 전까지 발생이 많고 여름철 고온건조한 시기에는 발생이 일시 정지하다가 9월 하순이후 다시 발생한다. 우리나라에서는 1971년 미국으로부터 유입되어 그 이후 문제가 된 병이다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("ecology1", "자낭균에 속하며 자낭포자 및 분생포자를 형성한다. 병든 잎, 병든가지의 인편에 형성된 자낭포자나 분생포자가 월동하여 1차전염원이 된다. 피해 낙엽에서는 이듬해 봄에 자낭각, 자낭，자낭포자 순으로 성숙된다. 비가 온 후 자낭각에서 자낭포자가 비산되어 잎이나 과실에 침입，발병한다. 자낭포자는 개화직전부터 낙화 20일까지 비 산되는 량이 많다. 병반상에 형성된 분생포자는 비에 의해 비산되어 2차 감염한다. 8월 이후에 감염된 과실은 수확 시에 병반을 나타내지 않고 저장 중에 발병하는 경우도 있다. 발생은 5월 중순부터 발병하기 시작하여 장마기 전까지 발생이 많고 여름철 고온건조한 시기에는 발생이 일시 정지하다가 9월 하순이후 다시 발생한다. 우리나라에서는 1971년 미국으로부터 유입되어 그 이후 문제가 된 병이다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[0].Add(new Field("image", "사과_검은별무늬병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[1].Add(new Field("Id", "2", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("name", "꽃 썩음 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("symptom", "병에 걸린 꽃 은2~3일 이내 에 갈색 으로 변하여 서리 피해 를 받은 것과 같 이 말라 죽게 된다. 어린 과실 에 일부 또는 반 정도가 썩은 반점 이 나타나고 과실 표면 에 황갈색 의 물방울 이 맺힌다. 잎 에는 잎 이 전개 된 후 어린 잎 의 주맥 으로부터 엽맥 에 길이 2~3cm 정도의 적갈색 의 변색 부를 나타내고 썩으며 심하면 잎 전체 가 갈색 으로 마른다. 가지 는 새로 나온 가지 가 갈색 으로 변 하고 말라 죽게 된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("symptom1", "병에 걸린꽃은2~3일 이내에 갈 색으로 변하여 서리피해를 받은 것과 같 이 말라 죽게 된다.어린 과실에 일부 또는 반 정도가 썩은 반점이 나타나고 과실 표면에 황갈색의 물방울이 맺힌다.잎에는 잎이 전개된 후 어린잎의 주맥으로부터 엽맥에 길이 2~3cm 정도의 적갈색의 변색부를 나타내고 썩으며 심하면 잎 전체가 갈색으로 마른다.가지는 새로 나온 가지가 갈색으로 변 하고 말라죽게 된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("species", "사과", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("ecology", "자낭균 의 일종 으로 균핵 및 자실체 를 형성 하고 자낭 포자 와  대형 의 분생 포자 를 형성 한다. 이른 봄 에 균핵 으로부터 자실체 가  형성 되고 그위에 자낭포자 가 형성 된다. 자낭포자 가 비산 ( 飛散 )  하여 개화기 의 어린 잎 이나 꽃을 침입 하여 잎 썩음 과 꽃 썩음 이 나타난다. 여기서 만들어진 분생포자 가  개화 중 주두 (柱頭)에 침입 하여 과실 썩음 을 일 으킨다. 병든 과실은 6월 중하순에 땅 에 떨어져 균핵 으로 되어 월동 한 후 이듬해 전염원 이 된다. 잎 의 발병 은 주로 개화기 직전 부터 6 월 상순 까지 볼 수 있다", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("ecology1", "자낭균의 일종으로 균핵 및 자실체를 형성하고 자낭포자와 대형의 분생포자를 형성한다. 이른봄에 균핵으로부터 자실체가 형성 되고 그위에 자낭포자가 형성된다. 자낭 포자가 비산(飛散)하여 개화기의 어린 잎이나 꽃을 침입하여 잎 썩음과 꽃 썩 음이 나타난다. 여기서 만들어진 분생포자가 개화 중 주두(柱頭)에 침입하여 과실 썩음을 일 으킨다. 병든 과실은 6월 중하순에 땅에 떨어져 균핵으로 되어 월동한 후 이듬해 전염원이 된다. 잎의 발병은 주로 개화기 직전부터 6 월 상순까지 볼 수 있다", Field.Store.YES, Field.Index.ANALYZED));
            Doc[1].Add(new Field("image", "사과_꽃썩음병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[2].Add(new Field("Id", "3", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("name", "검은 무늬 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("symptom", "잎 ，과실 ，신초 에 나타나는 병 으로 병원균 의 침입 은 부드럽고 어린 조직 을 통해서 이루어진다. 신초 끝의 잎 에만 발생 되고 병반 은 흑색 의 소립점 이  나타나서 흑점 주변 이 황색 으로 변하여 생육 이 정지 되며 잎 이 뒤틀리고 심하면 구멍 이 뚫린다. 병반상 에 포자 가 다량 형성 되고 동심 윤문 울 나타낸다. 신초 생장 이 계속되는 가지 에서만 감염 되며 흑색 의 원형 병반 이 형성 되나 그후 병반 이 확대 되어 타원형 의 대형 병반 으로 커지게 된다. 어린 과실 의 병반 은 5월 중순경에 둥글고 작은 흑점 의 병반 으로 시작하여 병반 부위 가 움룩 들어가고 굳어진다 6월 하순경에 병반 이 생긴 어린 과실 은 균열 이 생기고 급속 하게 확대 되어 낙과 된다. 성숙과 에서는 병반 이 동심윤문 으로 확대되면서 썩는다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("symptom1", "잎，과실，신초에 나타나는 병으로 병원균의 침입은 부드럽고 어린 조직을 통해서 이루어진다. 신초 끝의 잎에만 발생되고 병반은 흑색의 소립점이 나타나서 흑점 주변이 황색으로 변하여 생육이 정지되며 잎이 뒤틀리고 심하면 구멍이 뚫린다. 병반상에 포자가 다량 형성되고 동심 윤문울 나타낸다. 신초생장이 계속되는 가지에서만 감염되며 흑색의 원형 병반이 형성되나 그후 병반이 확대되어 타원형의 대형병반으로 커지게 된다. 어린 과실의 병반은 5월 중순경에 둥글고 작은 흑점의 병반으로 시작하여 병반 부위가 움룩 들어가고 굳어진다 6월 하순경에 병반이 생긴 어린 과실은 균열이 생기고 급속하게 확대되어 낙과된다. 성숙과에서는 병반이 동심윤문으로 확대되면서 썩는다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("species", "배", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("ecology", "불완전균 에 속하며 분생포자를 형성 한다. 병원균 은 병반 에서 균사 형태 로  월동 한다. 3월하순 병반 에서 포자 를 형성 하기 시작 하며 전염 된다. 분생 포자 형성 은 병반 에서 가을 까지 계속 해서 이루어진다. 병 발생 이 빠른 해에는 개화 시 평균기온 이 15t정도에서 2~3일이 되면 병반 이 보인다. 발생 은 5월에서 10월까지 계 속 발생 하나 6~7월의 기온 이 24-28 ˚C이고 다습 하면 많이 발생 한다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("ecology1", "불완전균에 속하며 분생포자를 형 성한다. 병원균은 병반에서 균사 형태로 월동한다. 3월하순 병반에서 포자를 형성 하기 시작하며 전염된다. 분생포자 형성은 병반에서 가을까지 계속해서 이루어진다. 병발생이 빠른 해에는 개화 시 평균기 온이 15t정도에서 2~3일이 되면 병반 이 보인다. 발생은 5월에서 10월까지 계 속 발생하나 6~7월의 기온이 24-28 ˚C이고 다습하면 많이 발생한다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[2].Add(new Field("image", "배_검은무늬병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[3].Add(new Field("Id", "4", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("name", "세균성 구멍 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("symptom", "세균성 구멍 병 은 자두 의 병해 가운데서 무엇보다도 피해가 크다. 잎 ，가지 ， 과실 에서 병 이 발생 한다. 잎 에는 처음 에 수침상 의 병 무늬 가 생기고，다음에 갈색 의 반점 이 되며，병 이 진전 되어 반점 의 주위에 이층 (離層) 을 만들어 떨어 지고 여러 개의 구멍 을 만든다. 또한 심하게 병 이 발생 한 잎 은 차례 로 잎 이 떨어진다. 과실 에는 처음 에 진한 녹색  또는 자주 빛 을 띠는 흑녹색 의 수침상 의 병반 을 만들며，다음에 혹색 내지 자흑색 으로 변 고 약간 움푹 패이며 가끔 균열 이 생긴다. 심해지면 병 에 걸린 과실 은 빨리 물 들어 연화 하고 과실 이 떨어지게 된다. 가지 는 처음 에 암갈색 의 움푹 들어간 병반 을 만들며，진액 을 분비 한다. 다음 에 는 주위 로 유상 조직 이 생기고，혹모양 이 되어 중심부 에 병반 이 생긴다. 심하게 발병 하면 병든 부분 부터 잎 이 마른다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("symptom1", "세균성구멍병은 자두의 병해 가운데서 무엇보다도 피해가 크다. 잎，가지，과실에서 병이 발생한다. 잎에는 처음에 수침상의 병무늬가 생기고，다음에 갈색의 반점이 되며，병이 진전되어 반점의 주위에 이층(離層)을 만들어 떨어 지고 여러 개의 구멍을 만든다. 또한 심하게 병이 발생한 잎은 차례로 잎이 떨어진다. 과실에는 처음에 진한 녹색 또는 자주 빛을 띠는 흑녹색의 수침상의 병반을 만들며，다음에 혹색내지 자흑색으로 변 고 약간 움푹 패이며 가끔 균열이 생긴다. 심해지면 병에 걸린 과실은 빨리 물 들어 연화하고 과실이 떨어지게 된다. 가지는 처음에 암갈색의 움푹 들어간 병반을 만들며，진액을 분비한다. 다음에 는 주위로 유상조직이 생기고，혹모양이 되어 중심부에 병반이 생긴다. 심하게 발병하면 병든 부분부터 잎이 마른다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("species", "자두", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("ecology", "세균성 구멍 병은 세균 병 으로 병원균 은 ' 복숭아 ’ 의 세균성 구멍 병균 과 같은 종류 이다. 인공 접종 시험 을 하여 보면. 복숭아 세균성구멍병균 은 ‘ 자두 ’에 감염 되며，또 그 반대로 ' 자두 ’ 세균성구멍병균 은 복숭아 에 감염 된다. 그러나. 박테리오파아지 ( 세균 감염성 바이러스 )을 이용 하여 그 성질 을 조사해 보면 두 가지 균 에는 차이 가 있으며 자두 세균성구멍병균 은 자두 에，복숭아 세균성 구멍 병균 은 복숭아 로 기주 가 나누어지는 것을 알 수 있다. 본 병 은 주로 가지 의 병반 , 낙엽 흔적 등에서 기생 하여 월동 하며, 전염 된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("ecology1", "세균성구멍병은 세균병으로 병원균은 '복숭아’의 세균성구멍병균과 같은 종류이다. 인공접종시험을 하여 보면. 복 숭아세균성구멍병균은 ‘자두’에 감염되며，또 그 반대로 '자두’ 세균성구멍병균은 복숭아에 감염된다. 그러나. 박테리오파아지 (세균 감염성 바이러스)을 이용하여 그 성질을 조사해 보면 두 가지 균에는 차이가 있으며 자두세균성구멍병균은 자두에，복숭아세균성 구 병균은 복숭아로 기주가 나누어지는 것을 알 수 있다. 본 병은 주로 가지의 병반, 낙엽흔적 등에서 기생하여 월동하며, 전염된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[3].Add(new Field("image", "자두_세균성구멍병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[4].Add(new Field("Id", "5", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("name", "세균성 구멍 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("symptom", "잎 ，가지 ， 과실 에서 병 이 발생 한다. 잎 은 처음 에 적갈색 의 수침상 병반 을 만들며， 다음에는 병반 의 주위에 이층 (離層)을 이루고 구멍 을 만든다. 병 이  걸린 잎 은 떨어지기 쉽게 되어 심하게 병 이 걸린 것부터 차례로 잎 이 떨어진다. 가지 에는 자갈색 의 병반 이 생기며，다음에는 표면 이 찢어지고，궤양 모양 이  된다. 과실 의 경우 에 처음 에는 바늘 이 돌기 한 것 같은 작은 반점 이 생기고，다음 에 확대 되어 암갈색 의 반점 이 되며，중심부 에 금 이 가기 시작 한다. ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("symptom1", "잎，가지，과실에서 병이 발생한다. 잎은 처음에 적갈색의 수침상 병반을 만들며， 다음에는 병반의 주위에 이층(離層)을 이루고 구멍을 만든다. 병이 걸린 잎은 떨어지기 쉽게 되어 심하게 병이 걸린 것부터 차례로 잎이 떨어진다. 가지에는 자갈색의 병반이 생기며，다음에는 표면이 찢어지고，궤양모양이 된다. 과실의 경 우에 처음에는 바늘이 돌기한 것 같은 작은 반점이 생기고，다음에 확대되어 암갈색의 반점이 되며，중심부에 금이 가기 시작한다. ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("species", "살구", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("ecology", "세균성 구멍 병 은 세균병 으로 병원세균 은 복숭아 세균성 구멍병 과 동일한 종류 이다. 1~6본의 극성편모 를 가지고 있는 짧은 볏짚 모양 의 세균 으로, 발육 적정 온도 는 22~ 28 °C 이다. 병원균 은 가지 의 병반 조직 내에서 월동 며 다음해 봄 주위의 조직 으로 퍼지고，거기 에서 새롭게 증식 한 세균 이 나와서 일차 전염 을 시킨다. 비 가 많이 내릴 경우 병 이 발생  하기 쉬우며, 특히 태풍 과 같은 세찬 바람 을 동반한 비 가 계속 되면 발병 이 더욱 심해진다 ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("ecology1", "세균성구멍병은 세균병으로 병원세균은 복숭아 세균성구멍병과 동일한 종류이다. 1~6본의 극성편모를 가지고 있는 짧은 볏짚모양의 세균으로, 발육적정 온도는 22~ 28 °C 이다. 병원균은 가지의 병반조직 내에서 월동 며 다음해 봄 주위의 조직으로 퍼지고，거기에서 새롭게 증식한 세균이 나와서 일차 전염을 시킨다. 비가 많이 내릴 경우 병이 발생 하기 쉬우며, 특히 태풍과 같은 세찬 바람을 동반한 비가 계속되면 발병이 더욱 심해진다 ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[4].Add(new Field("image", "살구_세균성구멍병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[5].Add(new Field("Id", "6", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("name", "흰 가루 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("symptom", "묘목 에 발 생이 많지만 실제 피해 는 그다지 크지 않다. 성숙한 나무 의 경우 무성한 가지 에 발생 하는 예가 많다. ' 살구 ’에는 Podosphaera tridactyla와 같은 복숭아 에 붙어 있는 균 과 동일 한 균 이 있는 것으로 알려져 있는데，' 살구 ’의 흰 가루 병 에  대해서는 보고된 바 가 없다. 주로 잎 에 발생 하며 처음에는 잎 이 퇴색 되고 잎 앞면 에 흰색 또는 연희색 의 균총 이 밀생 하게 된다. 심해지면 잎 이 황화 되고 조기 낙엽 된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("symptom1", "묘목에 발생이 많지만 실제 피해는 그다지 크지 않다. 성숙한 나무의 경우 무성한 가지에 발생하는 예가 많다. '살구’에는 Podosphaera tridactyla와 같은 복숭아에 붙어 있는 균과 동일한 균이 있는 것으로 알려져 있는데，'살구’의 흰가루병에 대해서는 보고된 바 가 없다. 주로 잎에 발생하며 처음에는 잎이 퇴색되고 잎 앞면에 흰색 또는 연희색의 균총이 밀생하게 된다. 심해지면 잎이 황화되고 조기 낙엽된다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("species", "살구", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("ecology", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("ecology1", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[5].Add(new Field("image", "살구_흰가루병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[6].Add(new Field("Id", "7", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("name", "황색 망반 병 ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("symptom", "황색 망반 병 에 관해서는 예전부터 발생 에 관하여 알려져 있었지만，최근까지 병명 은 정식 으로 붙여지지 않았다. 잎 에 병 이 발생 하며 증상 에 는 여러 가지 형태 가 있다. 황색망반병 은 바이러스 병 으로 접목 에 의하여 전염 되며, 이 병원 바이러스 는 외국 에 서 플람라인패턴 으로 불려지는 것과 동일한 바이러스 인 것으로 보이지만 좀더 많은 연구 가 진행 되고 나서 정확히 규명될 것으 로 보인다. 병 이 발생하기 시작하는 곳은 자두 와 벚나무 이다. 심하게 감염 된 나무는 멀리서 보았을 때 황색 으로 보인다. 그러나 실제 피해 는 그다지 크지 않다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("symptom1", "황색망반병에 관해서는 예전부터 발생에 관하여 알려져 있었지만，최근까지 병명은 정식으로 붙여지지 않았다. 잎에 병이 발생 하며 증상에는 여러 가지 형태가 있다. 황색망반병은 바이러스병으로 접목에 의하여 전염되며, 이 병원 바이러스는 외국에 서 플람라인패턴으로 불려지는 것과 동일한 바이러스인 것으로 보이지만 좀더 많은 연구가 진행되고 나서 정확히 규명될 것으 로 보인다. 병이 발생하기 시작하는 곳은 자두와 벚나무이다. 심하게 감염된 나무는 멀리서 보았을 때 황색으로 보인다. 그러나 실제 피해는 그다지 크지 않다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("species", "자두", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("ecology", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("ecology1", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[6].Add(new Field("image", "자두_황색망반병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[7].Add(new Field("Id", "8", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("name", "검은 곰팡이 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("symptom", "수확 한 다음 과실 이 숙성 하면서 발병 하는 경우가 많다. 병원균 은 썩는 성질 이 강한 균 으로 채소 나 과일 은 물론 각종 음식물 을 썩게 한다. 어디에나 있는 균 이기 때문에 과실 의 선택 ，운송 ，저장 및 가게 진열 시에 발병 하는 경우가 많다. 처음 에는 갈색 에 수침 상의 얼룩 점 이 생기고 급속도로 병세 가 진 전되어 모발 이 긴 명주실 과 같이 광택 이 있 는 균 덩어리 를 만들고, 다음으로 표면 에 검 은 회색 의 포자낭 을 만든다. 병 에 걸린 과일 은 연화 하여 과즙 이 흘러나오며，균사 는  신장 이 빨라져 주위 에 있는 과실 로 침범 한다", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("symptom1", "수확한 다음 과실이 숙성하면서 발병하는 경우가 많다. 병원균은 썩는 성질이 강한 균으로 채소나 과일은 물론 각종 음식물을 썩게 한다. 어디에나 있는 균이기 때문에 과 실의 선택，운송，저장 및 가게 진열 시에 발 병하는 경우가 많다. 처음에는 갈색에 수침 상의 얼룩점이 생기고 급속도로 병세가 진 전되어 모발이 긴 명주실과 같이 광택이 있 는 균 덩어리를 만들고, 다음으로 표면에 검 은 회색의 포자낭을 만든다. 병에 걸린 과일 은 연화하여 과즙이 흘러나오며，균사는 신 장이 빨라져 주위에 있는 과실로 침범한다", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("species", "복숭아", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("ecology", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("ecology1", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[7].Add(new Field("image", "복숭아_검은곰팡이병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[8].Add(new Field("Id", "9", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("name", "잿빛 곰팡이 병 ", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("symptom", "어린 과실 과 숙성 한 과실 모두에 침범 한다. 개화기 에 비가 많은 해에 꽃잎 이나 꽃받침 에 우선 침범 하고 뒤이어 이 병균 이 부착 된 어린 과실 에 침범 한다. 병균 에 침범 당한 부분 은 움푹 패이고 심해지면 과실 전체 가 풀 이 죽어 떨어진다. 성숙한 과실 의 경우， 주로 수확 후에 발병 하여 잿빛 곰팡이 를 만 드는 특징 이 있다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("symptom1", "어린 과실과 숙성한 과실 모두에 침범한다. 개화기에 비가 많은 해에 꽃잎이나 꽃받침에 우선 침범하고 뒤이어 이 병균이 부착 된 어린 과실에 침범한다. 병균에 침범당한 부분은 움푹 패이고 심해지면 과실 전체가 풀이 죽어 떨어진다. 성숙한 과실의 경우， 주로 수확 후에 발병하여 잿빛곰팡이를 만 드는 특징이 있다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("species", "복숭아", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("ecology", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("ecology1", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[8].Add(new Field("image", "복숭아_잿빛곰팡이병.jpg", Field.Store.YES, Field.Index.ANALYZED));

            Doc[9].Add(new Field("Id", "10", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("name", "과실 썩음 병", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("symptom", "성숙 과 에 발병 하는 병 이지만 감염 은 반 드시 나무 위에서 일어난다. 과실 썩음 병 의 병원균 은 가지 에 기생 하며，비가 내릴 때 포자 가 비산 하여 감염 되는 성질 을 갖고 있다. 처음에는 갈색 의 약간 움푹 패인 병 얼룩 을 만들며 잿빛 무늬병 과 같이 빠르지 않고 비 교적 천천히 퍼져 다음에 병무늬 표면 으로 오염 되 어 백색 내지는 검정색 의 작은 입자 ( 병자각 )을 빽빽하게 만든다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("symptom1", "성숙과에 발병하는 병이지만 감염은 반 드시 나무 위에서 일어난다. 과실썩음병의 병원균은 가지에 기생하며，비가 내릴 때 포 자가 비산하여 감염되는 성질을 갖고 있다. 처음에는 갈색의 약간 움푹 패인 병 얼룩을 만들며 잿빛무늬병과 같이 빠르지 않고 비 교적 천천히 퍼져 다음에 병무늬표면으로 오염되어 백색 내지는 검정색의 작은 입자 (병자각)을 빽빽하게 만든다.", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("species", "복숭아", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("ecology", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("ecology1", "", Field.Store.YES, Field.Index.ANALYZED));
            Doc[9].Add(new Field("image", "복숭아_과실썩음병.jpg", Field.Store.YES, Field.Index.ANALYZED));
        }

        public string[,] SearchTxT(string txt, int type)
        {
            
            Lucene.Net.Index.IndexReader indexReader = Lucene.Net.Index.IndexReader.Open(directory, true);
            Lucene.Net.Search.Searcher indexSearch = new Lucene.Net.Search.IndexSearcher(indexReader);

            string typetxt = "";
            string[,] str = new string[10, 2];
            string[,] str2 = new string[10, 2];
            

            if (type == 1 )
            {
                typetxt = "name";
            }
            else if(type == 2)
            {
                typetxt = "species";
            }
            else if (type == 3)
            {
                typetxt = "symptom";
            }
            else
            {
                typetxt = "ecology";
            }

            var queryParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, typetxt, analyzer);
            var query = queryParser.Parse(txt);
            
            Lucene.Net.Search.TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

            var hits = resultDocs.ScoreDocs;
            int i = 0;
            foreach (var hit in hits)
            {

                var documentFromSearch = indexSearch.Doc(hit.Doc);

                str[i, 0] = documentFromSearch.Get("Id");
                str[i, 1] = documentFromSearch.Get("name") + " - " + documentFromSearch.Get("species");
                i++;
            }

            return str;
        }

        public string[,] SearchId(string id,int type)
        {
            Console.WriteLine(id);


            Lucene.Net.Index.IndexReader indexReader = Lucene.Net.Index.IndexReader.Open(directory, true);
            Lucene.Net.Search.Searcher indexSearch = new Lucene.Net.Search.IndexSearcher(indexReader);
            

            var queryParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Id", analyzer);
            var query = queryParser.Parse(id);

            string[,] str = new string[1,6];
            str[0, 0] = type.ToString();

            Lucene.Net.Search.TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

            var hits = resultDocs.ScoreDocs;
            int i = 0;
            foreach (var hit in hits)
            {

                var documentFromSearch = indexSearch.Doc(hit.Doc);
                str[0, 1] = "Name : " + documentFromSearch.Get("name");
                str[0, 2] = "Species : " + documentFromSearch.Get("species");
                str[0, 3] = "Symptom : " + documentFromSearch.Get("symptom1");
                str[0, 4] = "Ecology : " + documentFromSearch.Get("ecology1");
                str[0, 5] = documentFromSearch.Get("image");
                i++;
            }

            return str;
        }


        /*    
        public string[] test(string txt, int type)
        {
            var fordFiesta = new Document();
            fordFiesta.Add(new Field("Id", "1", Field.Store.YES, Field.Index.NOT_ANALYZED));
            fordFiesta.Add(new Field("가사", "Ford tte", Field.Store.YES, Field.Index.ANALYZED));
            fordFiesta.Add(new Field("Model", "Fiesta", Field.Store.YES, Field.Index.ANALYZED));

            var vauxhallAstra = new Document();
            vauxhallAstra.Add(new Field("Id", "2", Field.Store.YES, Field.Index.NOT_ANALYZED));
            vauxhallAstra.Add(new Field("Make", "Ford", Field.Store.YES, Field.Index.ANALYZED));
            vauxhallAstra.Add(new Field("Model", "Astra", Field.Store.YES, Field.Index.ANALYZED));

            Document[] Parkhyoshin = new Document[2];
            Parkhyoshin[0] = new Document();
            Parkhyoshin[0].Add(new Field("Id", "3", Field.Store.YES, Field.Index.NOT_ANALYZED));
            Parkhyoshin[0].Add(new Field("가사", "오늘 하루 쉴 숨 이 오늘 하루 쉴 곳이 오늘만큼 이렇게 또 한번 살아가침대 밑에 놓아둔지난 밤에 꾼 꿈이지친 맘을 덮으며 눈을 감는다 괜찮아 남들과는 조금은 다른 모양 속에나 홀로 잠들어 다시 오는 아침에 눈을 뜨면 웃고프다 오늘 같은 밤 이대로 머물러도 될 꿈이라면 바랄 수 없는걸 바라도 된다면 두렵지 않다면 너처럼 오늘 같은 날 마른 줄 알았던 오래된 눈물이 흐르면 잠들지 않는 내 작은 가슴이 숨을 쉰다 끝도 없이 먼 하늘 날아가는 새처럼뒤돌아 보지 않을래 이 길 너머 어딘가 봄이 힘없이 멈춰있던세상에 비가 내리고다시 자라난 오늘그 하루를 살아오늘 같은 밤이대로 머물러도 될 꿈이라면바랄 수 없는걸 바라도 된다면두렵지 않다면 너처럼오늘 같은 날마른 줄 알았던 오래된 눈물이 흐르면잠들지 않는 이 어린 가슴이 숨을 쉰다고단했던 내 하루가 숨을 쉰다",
                 Field.Store.YES, Field.Index.ANALYZED));
            Parkhyoshin[0].Add(new Field("제목", "숨", Field.Store.YES, Field.Index.ANALYZED));
            Parkhyoshin[0].Add(new Field("가수", "박효신", Field.Store.YES, Field.Index.ANALYZED));

            Parkhyoshin[1] = new Document();
            Parkhyoshin[1].Add(new Field("Id", "3-1", Field.Store.YES, Field.Index.NOT_ANALYZED));
            Parkhyoshin[1].Add(new Field("가사", "하얗게 피어난 얼음 꽃 하나가달가운 바람에 얼굴을 내밀어아무 말 못했던 이름도 몰랐던지나간 날들에 눈물이 흘러차가운 바람에 숨어 있다한줄기 햇살에 몸 녹이다그렇게 너는 또 한번 내게 온다좋았던 기억만그리운 마음만니가 떠나간 그 길 위에이렇게 남아 서 있다잊혀질 만큼만괜찮을 만큼만눈물 머금고 기다린 떨림 끝에다시 나를 피우리라사랑은 피고 또 지는 타버리는 불꽃빗물에 젖을까 두 눈을 감는다어리고 작았던 나의 맘에눈부시게 빛나던 추억 속에그렇게 너를 또 한번 불러본다좋았던 기억만그리운 마음만니가 떠나간 그 길 위에이렇게 남아 서 있다잊혀질 만큼만괜찮을 만큼만눈물 머금고 기다린 떨림 끝에 다시 나는메말라가는 땅 위에온몸이 타 들어가고내 손끝에 남은너의 향기 흩어져 날아가멀어져 가는 너의 손을붙잡지 못해 아프다살아갈 만큼만미워했던 만큼만먼 훗날 너를 데려다 줄그 봄이 오면 그날에나 피우리라 라 라라라라 라 라 라라라라 라 라 라라 라 라라라 라~",
                 Field.Store.YES, Field.Index.ANALYZED));
            Parkhyoshin[0].Add(new Field("제목", "야생화", Field.Store.YES, Field.Index.ANALYZED));
            Parkhyoshin[1].Add(new Field("가수", "박효신", Field.Store.YES, Field.Index.ANALYZED));

            Document girlfriends = new Document();
            girlfriends.Add(new Field("Id", "4", Field.Store.YES, Field.Index.NOT_ANALYZED));
            girlfriends.Add(new Field("가사", "널 향한 설레임을 오늘 부터 우리는꿈꾸며 기도하는 오늘부터 우리는저 바람에 노을빛 내 맘을 실어 보낼게그리운 마음이 모여서 내리는Me gustas tu gustas tusu tu tu ru 좋아해요gustas tu su tu ru ru한 발짝 뒤에 섰던 우리는 언제쯤 센치해질까요서로 부끄러워서 아무 말도 못하는너에게로 다가가고 싶은데바람에 나풀거리는 꽃잎처럼 미래는 알 수가 없잖아이제는 용기 내서 고백할게요하나보단 둘이서 서로를 느껴 봐요내 마음 모아서 너에게 전하고 싶어설레임을 오늘부터 우리는꿈꾸며 기도하는 오늘부터 우리는저 바람에 노을빛 내 맘을 실어 보낼게그리운 마음이 모여서 내리는Me gustas tu gustas tusu tu tu ru 좋아해요gustas tu su tu ru ru한걸음 앞에 서서 두 손을 놓지 말기로 약속해요소중해질 기억을 꼭꼭 담아 둘게요 지금보다 더 아껴 주세요달빛에 아른거리는 구름처럼아쉬운 시간만 가는데 이제는 용기 내서 고백할게요둘보단 하나되어 서로를 느껴 봐요내 마음 모아서 너에게 전하고 싶어 설레임을 오늘부터 우리는꿈꾸며 기도하는 오늘부터 우리는저 바람에 노을빛 내 맘을 실어 보낼게 그리운 마음이 모여서 내리는 감싸 줄게요 (감싸 줄게요)그대 언제까지나 (언제까지나)사랑이란 말 안해도 느낄 수 있어요고마운 마음을 모아서 (no no no no)널 향한 설레임을 오늘부터 우리는 (오늘부터 우리는)꿈꾸며 기도하는 오늘부터 우리는 (오늘부터 우리는)저 바람에 노을빛 내 맘을 실어 보낼게 그리운 마음이 모여서 내리는Me gustas tu gustas tusu tu tu ru 좋아해요gustas tu su tu ru ru",
                 Field.Store.YES, Field.Index.ANALYZED));
            girlfriends.Add(new Field("제목", "오늘부터우리는", Field.Store.YES, Field.Index.ANALYZED));
            girlfriends.Add(new Field("가수", "여자친구", Field.Store.YES, Field.Index.ANALYZED));

            Document b1a4 = new Document();
            b1a4.Add(new Field("Id", "5", Field.Store.YES, Field.Index.NOT_ANALYZED));
            b1a4.Add(new Field("가사", "uhuh uh yeahwhat you do todayhey you still awake?oh girloff to bed with yougood night 그래요 오늘은 먼저 자요그대 잠들면 나도 잘게요전화를 끊고 화려한 옷을 입고 나갈 준비를 하죠아무도 모르게 whoo~tonight 오늘 하루만 그댈 속일게tonight 오늘이 지나면 돌아갈게tonight 가끔 어색하게도 느껴도 알아도 좀 넘어가 주겠니baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~머리 속에 오늘 그대가 없네요baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~미안해요 오늘 그대가 없네요oh 자정이 다 돼서 나갈 채비그대는 아직도 모를 테지문자 하날 남겨 “잘자 자기야 내일봐”근데 이 찝찝한 기분은 뭘까에라 몰라 그냥 나가자오늘도 moonlight불타는 이 밤 good nighttonight 오늘 하루만 그댈 속일게tonight 오늘이 지나면 돌아갈게tonight 가끔 답이 없어도 늦어도 미워도 좀 넘어가 주겠니baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~머리 속에 오늘 그대가 없네요baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~미안해요 오늘 그대가 없네요이유 없는 떨림에 내 가슴만 두근니가 보고 싶다던 생각은 오늘도 퇴근but 오늘은 바쁜 몸나는 참 나쁜 놈가끔은 이렇게 놀아도 돼넌 내일 쯤에 찾아 가면 되니까(sorry~)baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~머리 속에 오늘 그대가 없네요baby good night잘자요 good night그럼 난 dancing dancing dancing in the moonlight워어어우 워어~워어어우 워어~미안해요 오늘 그대가 없네요good night 우워어어우 워어~good night 우워어어우 워어~good night 우워어어우 워어~미안해요 오늘 그대가 없네요미안해요 오늘 그대가 없네요미안해요 오늘 그대가 없네요",
                 Field.Store.YES, Field.Index.ANALYZED));
            b1a4.Add(new Field("제목", "잘자요 굿나잇", Field.Store.YES, Field.Index.ANALYZED));
            b1a4.Add(new Field("가수", "B1A4", Field.Store.YES, Field.Index.ANALYZED));

            Document bts = new Document();
            bts.Add(new Field("Id", "6", Field.Store.YES, Field.Index.NOT_ANALYZED));
            bts.Add(new Field("가사", "떨어져 날리는 저기 낙엽처럼힘없이 쓰러져만 가 내 사랑이니 맘이 멀어져만 가 널 잡을 수 없어 더 더 더 잡을 수 없어 난더 붙들 수 없어 yeah저기 저 위태로워 보이는 낙엽은 우리를 보는 것 같아서손이 닿으면 단숨에라도 바스라질 것만 같아서그저 바라만 봤지 가을의 바람과 같이어느새 차가워진 말투와 표정관계는 시들어만 가는 게 보여가을 하늘처럼 공허한 사이예전과는 다른 모호한 차이 오늘 따라 훨씬 더 조용한 밤가지 위에 달린 낙엽 한 장부서지네 끝이란 게 보여, 말라가는 고엽초연해진 마음속의 고요제발 떨어지지 말아주오떨어지지 말아줘 바스라지는 고엽내 눈을 마주치는 너를 원해다시 나를 원하는 널 원해제발 떨어지지 말어쓰러지려 하지 말어Never, never fall멀리 멀리 가지 마Baby you girl 놓지 못하겠는걸Baby you girl 포기 못하겠는걸떨어지는 낙엽들처럼이 사랑이 낙엽들처럼Never, never fall시들어가고 있어모든 낙엽은 떨어지듯이영원할 듯하던 모든 건 멀어지듯이너는 나의 다섯 번째 계절널 보려 해도 볼 수 없잖아봐 넌 아직 내겐 푸른색이야마음은 걷지 않아도 저절로 걸어지네미련이 빨래처럼 조각조각 널어지네붉은 추억들만 더러운 내 위에 덜어지네내 가지를 떨지 않아도 자꾸만 떨어지네그래 내 사랑은 오르기 위해 떨어지네가까이 있어도 나의 두 눈은 멀어지네 벌어지네이렇게 버려지네추억 속에서 난 또 어려지네Never, never fall yeahNever, never fall yeah내 눈을 마주치는 너를 원해다시 나를 원하는 널 원해제발 떨어지지 말어쓰러지려 하지 말어Never, never fall멀리 멀리 가지 마왜 난 아직도 너를 포기 못해 난시들어진 추억을 붙잡고욕심인 걸까? 지는 계절을 되돌리려 해돌리려 해타올라 붉게 활활다 아름다웠지 우리의 길 위엔근데 시들어버리고낙엽은 눈물처럼 내리고바람이 불고 다 멀어지네 all day비가 쏟아지고 부서지네마지막 잎새까지 넌 넌 넌내 눈을 마주치는 너를 원해다시 나를 원하는 널 원해제발 떨어지지 말어쓰러지려 하지 말어Never, never fall멀리 멀리 가지 마Baby you girl 놓지 못하겠는걸Baby you girl 포기 못하겠는걸떨어지는 낙엽들처럼 이 사랑이 낙엽들처럼Never, never fall시들어가고 있어Never, never fallNever, never fall",
                 Field.Store.YES, Field.Index.ANALYZED));
            bts.Add(new Field("제목", "고엽", Field.Store.YES, Field.Index.ANALYZED));
            bts.Add(new Field("가수", "BTS", Field.Store.YES, Field.Index.ANALYZED));

            //Document[] mushroom = new Document[5];
            //for(int j = 0; j < 5; j++)
            //{
            //    mushroom[j] = new Document();
            //}
            //mushroom[0].Add(new Field("Id", "5", Field.Store.YES, Field.Index.NOT_ANALYZED));


            Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));

            Lucene.Net.Analysis.Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            var writer = new Lucene.Net.Index.IndexWriter(directory, analyzer, true, Lucene.Net.Index.IndexWriter.MaxFieldLength.LIMITED);

            writer.AddDocument(fordFiesta);
            writer.AddDocument(vauxhallAstra);
            writer.AddDocument(Parkhyoshin[0]);
            writer.AddDocument(Parkhyoshin[1]);
            writer.AddDocument(girlfriends);
            writer.AddDocument(b1a4);
            writer.AddDocument(bts);

            writer.Optimize();

            writer.Close();

            Lucene.Net.Index.IndexReader indexReader = Lucene.Net.Index.IndexReader.Open(directory, true);
            Lucene.Net.Search.Searcher indexSearch = new Lucene.Net.Search.IndexSearcher(indexReader);



            string typetxt = "";

            if(type == 1)
            {
                typetxt = "가수||제목||가사";
            }
            else if (type == 2)
            {
                typetxt = "가수";
            }
            else if (type == 3)
            {
                typetxt = "제목";
            }
            


           var queryParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, typetxt, analyzer);
            //var query = queryParser.Parse("오늘");
            var query = queryParser.Parse(txt);

            string[] str = new string[10];

            str[0] = "Searching For " + query.ToString()+"\n";

            Lucene.Net.Search.TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

            var hits = resultDocs.ScoreDocs;
            int i = 1;
            foreach (var hit in hits)
            {

                var documentFromSearch = indexSearch.Doc(hit.Doc);
                //str[i] = i.ToString() + (". ") + documentFromSearch.Get("가수") + " " + documentFromSearch.Get("제목") + "\n" + documentFromSearch.Get("가사");
                str[i] = documentFromSearch.Get(typetxt);
                i++;
            }
            
            
            //for(int i =0; i <4; i++)
            // {
            //    var documentFromSearch = indexSearch.Doc(i);
            //    str[i+1] = documentFromSearch.Get("가수").ToString() + " " + documentFromSearch.Get("제목").ToString() + "\n" + documentFromSearch.Get("가사").ToString();

            // }
           // foreach (var hit in hits)
            {
           // var documentFromSearch = indexSearch.Doc(hit.Doc);
            // return documentFromSearch.Get("가수").ToString() + " " + documentFromSearch.Get("제목").ToString() + "\n" + documentFromSearch.Get("가사").ToString();
            // return str;
             }
            return str;
        }
        */
    }
}
