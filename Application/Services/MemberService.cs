using System;
using System.Collections.Generic;
using System.IO;
using Application.Interfaces;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using static Domain.Constants.Constants;

namespace Application.Services
{
    public class MemberService: IMemberService
    {
        private readonly IMemberRepository memberRepository;
        private readonly IImageService imageService;
        public MemberService(IMemberRepository memberRepository, IImageService imageService)
        {
            this.memberRepository = memberRepository;
            this.imageService = imageService;
        }

        public Member AddMember(Member member)
        {
            return memberRepository.AddMember(member);
        }

        public Member UpdateMember(Member member)
        {
            member.UpdateDate = DateTime.Now;
            return memberRepository.UpdateMember(member);
        }

        public Member GetMember(int Id)
        {
            return memberRepository.GetMember(Id);
        }

        public List<Member> GetAllMembers()
        {
            return memberRepository.GetAllMembers();
        }

        public List<Member> GetMembers()
        {
            return memberRepository.GetMembers();
        }
    }
}
