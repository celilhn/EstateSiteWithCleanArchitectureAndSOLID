using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class MemberService: IMemberService
    {
        private readonly IMemberRepository memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public Member SaveMember(Member member)
        {
            if (member.Id > 0)
            {
                member.UpdateDate = DateTime.Now;
                memberRepository.UpdateMember(member);
            }
            else
            {
                memberRepository.AddMember(member);
            }
            return member;
        }

        public Member GetMember(int Id)
        {
            return memberRepository.GetMember(Id);
        }

        public List<Member> GetMembers()
        {
            return memberRepository.GetMembers();
        }
    }
}
