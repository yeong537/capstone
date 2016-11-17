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
        public string[] test(string txt)
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

            var queryParser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "가사", analyzer);
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
                str[i] = i.ToString() + (". ") + documentFromSearch.Get("가수") + " " + documentFromSearch.Get("제목") + "\n" + documentFromSearch.Get("가사");
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
    }
}
